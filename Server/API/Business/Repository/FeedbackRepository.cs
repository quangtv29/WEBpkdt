using API.Business.Repository.IRepository;
using API.Business.Shared;
using API.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Repository
{
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(DataContext db) : base(db)
        {
        }

        public  void CreateFeedback(Feedback feedback)
        {
            Create(feedback);
        }

        public async Task<IEnumerable<Feedback>> getFeedbackByProduct(Guid? productID, FeedbackParameters feedbackParameters)
        {
            var result = await GetAllByCondition(p => p.ProductId == productID, false)
                .Where(p => p.isDelete == false)
                .Skip((feedbackParameters.PageNumber - 1) * feedbackParameters.PageSize)
                .Take(feedbackParameters.PageSize)
                .ToListAsync();
            return result;
        }
    }
}
