
using API.Business.DTOs.FeedbackDTO;
using API.Business.Shared;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IFeedbackService
    {
        Task<Feedback> createFeedback(CreateFeedbackDTO feedback);

        Task<IEnumerable<GetFeedbackByProductDTO>> getFeedbackByProduct(Guid?  productId, FeedbackParameters feedbackParameters);
    }
}
