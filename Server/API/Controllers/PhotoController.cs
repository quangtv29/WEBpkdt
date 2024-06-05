using API.Business.DTOs.PhotoDTO;
using API.Business.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PhotoController : BaseApiController
    {
        private readonly IServiceManager _service;

        public PhotoController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost("createPhoto")]
        public async Task<IActionResult> createPhoto ([FromForm]CreatePhotoDTO photo)
        {
          await  _service.photoService.CreatePhoto(photo);
            return Ok();
        }

        [HttpGet("getPhotoByProduct")]
        public async Task<IActionResult> getPhotoByProduct (Guid Id)
        {
            var result = await _service.photoService.getPhotoByProduct(Id);
            return Ok(result);
        }
    }
}
