using API.Business.DTOs.NotificationDTO;
using API.Business.Services.Interface;
using API.Business.Shared;
using API.Entities;
using API.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace API.Controllers
{
    public class NotificationController : BaseApiController
    {
        private readonly IServiceManager _service;
        private readonly IHubContext<NotificationHub> _notiHub;
        public NotificationController(IServiceManager service, IHubContext<NotificationHub> notiHub)
        {
            _service = service;
            _notiHub=notiHub;
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
                var noti = await _service.notificationService.createNoti(createNotificationDTO);
                await _notiHub.Clients.All.SendAsync("meo");
                return Ok(noti);
        }
        [HttpPost("updateNoti")]
        public async Task<IActionResult> updateNoti (Guid? id)
        {
            if (id == null)
            {
                return BadRequest("Id null");
            }
            var result = await _service.notificationService.updateNoti(id);
            if (result == null)
            {
                return BadRequest("Update fail");
            }    
            return Ok(result);
        }
    }
}
