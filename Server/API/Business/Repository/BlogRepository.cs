using API.Business.Repository.IRepository;
using API.Database;
using API.Entities;

namespace API.Business.Repository
{
    public class BlogRepository : RepositoryBase<Blog>, IBlogRepository
    {
        public BlogRepository(DataContext db) : base(db)
        {
        }


        public void CreateBlog (Blog blog)
        {
            Create(blog);
        }
    }
}
