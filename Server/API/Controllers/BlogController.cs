using API.Business.DTOs.BlogDTO;
using API.Business.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BlogController : BaseApiController
    {
        private readonly IServiceManager _service;

        public BlogController(IServiceManager service)
        {
            _service = service;
        }
        [HttpPost("CreateBlog")]
        public async Task<IActionResult> CreateBlog([FromForm]CreateBlogDTO createBlogDTO)
        {
            try
            {
                var result = await _service.blogService.CreateBlog(createBlogDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getBlog")]
       public async Task<IActionResult> getAllBlog()
        {
            var result = await _service.blogService.getAllBlog();
            return Ok(result);
        }

        [HttpGet("getBlogByID")]

        public async Task<IActionResult> getBlogById(Guid? Id)
        {
            try
            {
                var result = await _service.blogService.getBlogById(Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
