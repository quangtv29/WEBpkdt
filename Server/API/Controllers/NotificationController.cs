using API.Business.DTOs.NotificationDTO;
using API.Business.Services.Interface;
using API.Business.Shared;
using API.Entities;
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
            foreach(var re in result)
            {
               re.FormatDate = re.Create.ToString("dd/MM/yyyy HH:mm");
            }    
          
            return Ok(result);
        }

        [HttpPost("createNoti")]

        public async Task<IActionResult> createNoti(CreateNotificationDTO createNotificationDTO)
        {
            try
            {
                var noti = await _service.notificationService.createNoti(createNotificationDTO);
                return Ok(noti);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
