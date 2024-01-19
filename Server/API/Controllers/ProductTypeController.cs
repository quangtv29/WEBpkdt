using Microsoft.AspNetCore.Mvc;
using API.Business.Services.Interface;
using System.Net;
using API.Business.DTOs.ProductTypeDTO;
using API.Business.Helper;

namespace API.Controllers
{
    public class ProductTypeController : BaseApiController
    {
        private readonly IServiceManager _service;

        public ProductTypeController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]

        public async Task<IActionResult> getAll()
        {
            try
            {
                var productType = await _service.productTypeService.GetAll();
                return Ok(new
                {
                    Message = "Success",
                    Data = productType,
                    StatusCode = HttpStatusCode.OK
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost("createProductType")]

        public async Task<IActionResult> createProductType (CreateProductTypeDTO productTypeDTO)
        {
            if (productTypeDTO == null)
            {
                return Ok(new ApiResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Input is null"
                });
            }
       var result =   await   _service.productTypeService.createProductType(productTypeDTO);
            return Ok(new 
            {
                Message = "Create Success",
                StatusCode = HttpStatusCode.Created,
                Data = result
            });
        }

        [HttpGet("getProductType/{Id}")]

        public async Task<IActionResult> getProductTypeById (Guid? Id)
        {
            var productType = await _service.productTypeService.GetProductTypeById(Id);
            return Ok(productType);
        }

        [HttpPut("updateProductType/{Id}")]

        public async Task< IActionResult> updateProductType( UpdateProducTypeDTO producTypeDTO, Guid? Id)
        {
            if (Id == null)
            {
                return Ok(new ApiResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Id is null"
                });
            }
            await  _service.productTypeService.updateProductType(producTypeDTO,Id);
            return Ok(new ApiResponse
            {
                Message = "Success",
                StatusCode = HttpStatusCode.OK
            }) ;
        }

        [HttpPost]

       public async Task<IActionResult> delete(Guid? id)
        {
            var result = await _service.productTypeService.delete(id);
            if (result == 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
