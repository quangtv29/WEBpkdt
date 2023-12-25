
using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface IBlogRepository : IRepositoryBase<Blog>
    {
        void CreateBlog(Blog blog);
    }
}
