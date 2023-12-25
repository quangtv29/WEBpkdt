using API.Business.DTOs.FeedbackDTO;
using API.Business.Services.Interface;
using API.Business.Shared;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.WebSockets;

namespace API.Controllers
{
    public class FeedbackController : BaseApiController
    {
        private readonly IServiceManager _service;

        public FeedbackController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost("CreateFeedback")]

        public async Task<IActionResult> createFeedback([FromForm]CreateFeedbackDTO feedback)
        {
            try
            {
                if (feedback.ProductId == null || feedback.Star == null)
                {
                    return BadRequest(new
                    {
                        Message = "Star is null"
                    });
                }
             var result =   await _service.feedbackService.createFeedback(feedback);
                if (result == null)
                {
                    return BadRequest("Sản phẩm đã được đánh giá");
                }    
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("getFeedbackByProduct")]

        public async Task<IActionResult> getFeedbackByProduct(Guid? ProductId, FeedbackParameters feedbackParameters, int star)
        {
            if (ProductId == null)
            {
                return BadRequest(HttpStatusCode.NotFound);
            }    
            var result = await _service.feedbackService.getFeedbackByProduct(ProductId, feedbackParameters, star);
            foreach(var re in result)
            {
                var user = await _service.authenticationService.getInfoById(re.UserName);
                var customer = await _service.customerService.getCustomerByIDD(re.UserName);
                re.FixName = user.UserName;
                re.Avatar = customer.Image;
            }    
            
            var convert = result.Select(p =>
            {
                p.Convert = p.LastModificationTime.ToString("dd/MM/yyyy HH:mm:ss");
                return p;
            }).ToList();
            return Ok(convert);
        }
    }
}
        