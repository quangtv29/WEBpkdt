using API.Business.DTOs.FeedbackDTO;
using API.Business.Services.Interface;
using API.Business.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    public class FeedbackController : ControllerBase
    {
        private readonly IServiceManager _service;

        public FeedbackController(IServiceManager service)
        {
            _service = service;
        }

        [HttpPost("CreateFeedback")]

        public async Task<IActionResult> createFeedback(CreateFeedbackDTO feedback)
        {
            try
            {
                if (feedback.ProductId == null || feedback.Star == null)
                {
                    return Ok(new
                    {
                        Message = "Star is null"
                    });
                }
                await _service.feedbackService.createFeedback(feedback);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("getFeedbackByProduct")]

        public async Task<IActionResult> getFeedbackByProduct(Guid? ProductId, FeedbackParameters feedbackParameters)
        {
            if (ProductId == null)
            {
                return BadRequest(HttpStatusCode.NotFound);
            }    
            var result = await _service.feedbackService.getFeedbackByProduct(ProductId, feedbackParameters);
            return Ok(result);
        }
    }
}
        