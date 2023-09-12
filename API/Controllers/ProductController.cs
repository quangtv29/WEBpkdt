using API.Business.DTOs.ProductDTO.cs;
using API.Business.Helper;
using API.Business.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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

                return Ok(new ApiResponse
                {
                    StatusCode = (HttpStatusCode.Created), //201
                    Message = "Create Product Success"
                });
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
                return Ok(new ApiResponse
                {
                    StatusCode= (HttpStatusCode.OK)
                });            
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
                if (Id == null)
                {
                    return Ok(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Message = "Invalid request. Missing Id"
                    });
                }
                var product = await _service.productService.GetProductById(Id);
                if (product == null)
                {
                    return BadRequest(HttpStatusCode.NotFound);
                }
                return Ok(new
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = product,
                    Message = "Done"
                });
            }
            catch (Exception ex) {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [HttpDelete ("{Id}")]


        public async Task<IActionResult> deleteProduct (Guid? Id)
        {
            if (Id == null)
            {
                return Ok(new ApiResponse
                {
                    StatusCode = HttpStatusCode.BadRequest
                });
            }
            await _service.productService.deleteProduct(Id);
            return Ok(new ApiResponse
            {
                Message = "Success",
                StatusCode = HttpStatusCode.OK
            });
        }
    }
}



//{
//    "statusCode": 200,
//  "message": "Login Success",
//  "data": "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Im1haWkiLCJJZCI6IjdiMTNkYzBlLWJjY2YtNGQ3Yi1mNGIwLTA4ZGJhMGFmNzc5ZiIsIm5iZiI6MTY5NDUzMTg4OCwiZXhwIjoxNjk0NjE4Mjg4LCJpYXQiOjE2OTQ1MzE4ODh9.ANIcYa3OZiBRAlvfSgiRvJHgiOo6OrZkTmwmDlGjIOE1TVZ84uzK1THSsu6rzTsLY20l3nVCj9_NLHYS-Z_kzA"
////}