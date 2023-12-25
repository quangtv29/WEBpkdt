
using API.Business.DTOs.FeedbackDTO;
using API.Business.Shared;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IFeedbackService
    {
        Task<Feedback> createFeedback(CreateFeedbackDTO feedback);
        Task<string> SaveImage(IFormFile imageFile);

        Task<IEnumerable<Feedback>> getFeedbackByProduct(Guid?  productId, FeedbackParameters feedbackParameters, int star);
    }
}
