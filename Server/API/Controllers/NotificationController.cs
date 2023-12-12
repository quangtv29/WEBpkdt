using API.Business.Services.Interface;
using API.Business.Shared;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class NotificationController : BaseApiController
    {
        private readonly IServiceManager _service;

        public NotificationController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost("getNotiByCustomerId")]
        
        public async Task<IActionResult> getNotiByCustomerId(string customerId, [FromBody] NotificationParameter notificationParameter)
        {
            var result = await _service.notificationService.getNotificationByCustomerId(customerId, notificationParameter);
            return Ok(result);
        }
    }
}
