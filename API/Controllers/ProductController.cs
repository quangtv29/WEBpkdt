using API.Business.DTOs.ProductDTO.cs;
using API.Business.Helper;
using API.Business.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IServiceManager _service;
        private readonly IMapper _mapper;

        public ProductController(IServiceManager service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("getAllProduct")]

        public async Task<IActionResult> getAllProduct()
        {
            try
            {
                var products = await _service.productService.GetAll();
                if (products == null)
                {
                    return BadRequest(HttpStatusCode.NoContent);
                }
                var convert = products.Select(p =>
                {
                    p.formatPrice = Helper.ConvertToMoney<int?>(p.Price);
                    p.formatImportPrice = Helper.ConvertToMoney<int?>(p.ImportPrice);
                    return p;
                }).ToList();

                var productDTO = _mapper.Map<List<GetAllProductDTO>>(convert);

                return Ok(productDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost("GetProductByIds")]

        public async Task<IActionResult> getProductByIds (IEnumerable<Guid>? Ids)
        {
            try
            {
                var product = await _service.productService.GetProductByIds(Ids);
                if (product == null)
                {
                    return BadRequest(HttpStatusCode.NotFound);
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("updateProduct/{Id}")]
        
        public async Task<IActionResult> updateProduct ([FromBody] UpdateProductDTO product, Guid? Id)
        {
            try
            {
                await _service.productService.Update(product, Id);
                return Ok("ok");            
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> getProductById (Guid? Id)
        {
            try
            {
                var product = await _service.productService.GetProductById(Id);
                if (product == null)
                {
                    return BadRequest(HttpStatusCode.NotFound);
                }
                return Ok(product);
            }
            catch (Exception ex) {
                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}



