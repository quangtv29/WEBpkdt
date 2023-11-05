using API.Business.DTOs.FeedbackDTO;
using API.Business.Shared;
using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IFeedbackRepository : IRepositoryBase<Feedback>
    {
       void CreateFeedback(Feedback feedback);

        Task<IEnumerable<Feedback>> getFeedbackByProduct(Guid? productID, FeedbackParameters feedbackParameters);
    }
}
