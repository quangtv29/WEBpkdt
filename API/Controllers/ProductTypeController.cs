using Microsoft.AspNetCore.Mvc;
using API.Business.Services.Interface;
using System.Net;

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
    }
}
