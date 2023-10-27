using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;

namespace API.Business.Repository
{
    public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(DataContext db) : base(db)
        {
        }
    }
}
