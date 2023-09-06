using Microsoft.AspNetCore.Mvc;
using API.Business.Services.Interface;
using System.Net;
using Microsoft.Identity.Client;
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
                if (productType == null)
                {
                    return BadRequest(HttpStatusCode.NoContent);
                }
                return Ok(productType);
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

        public IActionResult createProductType (CreateProductTypeDTO productTypeDTO)
        {
            _service.productTypeService.createProductType(productTypeDTO);
            return Ok("done");
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
          await  _service.productTypeService.updateProductType(producTypeDTO,Id);
            return Ok(new ApiResponse
            {
                Message = "Success",
                StatusCode = HttpStatusCode.OK
            }) ;
        }


    }
}
