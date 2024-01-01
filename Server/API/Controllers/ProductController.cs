using API.Business.DTOs.ProductDTO.cs;
using API.Business.Helper;
using API.Business.Services.Interface;
using API.Business.Shared;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.InteropServices;

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

        [HttpPost("getAllProduct")]

        public async Task<IActionResult> getAllProduct([FromBody] ProductParameters productParameters, int a)
        {
            try
            {
                var products = await _service.productService.GetAll(productParameters, a);
                if (products.Item1 == null)
                {
                    return BadRequest(HttpStatusCode.NoContent);
                }

                var productDTO = _mapper.Map<List<GetAllProductDTO>>(products.Item1);

                return Ok(new
                {
                    productDTO,
                    products.Item2
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("CreateProduct")]
       
        public async Task<IActionResult> createProduct([FromForm] CreateProductDTO product)
        {
            try
            {
                var result = await _service.productService.CreateProduct(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("meo")]
        [DisableRequestSizeLimit]

        public IActionResult meo(IFormFile image)
        {
            try
            {
                // Xử lý tệp tin của bạn ở đây
                return Ok("meo");
            }
            catch (Exception ex)
            {
                return BadRequest($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        [HttpPost("GetProductByIds")]

        public async Task<IActionResult> getProductByIds(IEnumerable<Guid>? Ids)
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
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> updateProduct([FromBody] UpdateProductDTO product, Guid? Id)
        {
            try
            {
                await _service.productService.Update(product, Id);
                return Ok(new ApiResponse
                {
                    StatusCode = (HttpStatusCode.OK)
                });
            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{Id}")]

        public async Task<IActionResult> getProductById(Guid? Id)
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
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }

        [HttpDelete("{Id}")]
        [Authorize(Roles = "Manager")]

        public async Task<IActionResult> deleteProduct(Guid? Id)
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

        [HttpPost("searchByName")]

        public async Task<IActionResult> searchByName(string name, ProductParameters productParameters)
        {
            var result = await _service.productService.searchByName(name, productParameters);
            return Ok(new { result.Item1, result.Item2 });
        }

        [HttpPost("updateProduct")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> updateProduct( [FromForm] UpdateProductDTO product)
        {
            try
            {
                if (product.Id == null)
                {
                    return BadRequest("Update Fail - Id null");
                }
                var result = await _service.productService.updateProduct( product);
                if (result == null)
                {
                    return BadRequest("Update Fail - Id does n't exists");
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest("Update fail");
            }
        }
        [HttpPost("getByPrice")]
        public async Task<IActionResult> getProductByPrice(int? vip, int? to, ProductParameters productParameters, bool inStock, bool outOfStock)
        {
            
            return Ok( await _service.productService.getProductByPrice(vip, to, productParameters,inStock,outOfStock));
        }

        [HttpPost("getProductByProductType")]
        public async Task<IActionResult> getProductByProductType(string? productType, ProductParameters productParameters)
        {
            try
            {
                var result = await _service.productService.getProductByProductType(productType, productParameters);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}



