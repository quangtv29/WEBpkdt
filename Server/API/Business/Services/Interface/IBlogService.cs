using API.Business.DTOs.BlogDTO;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface IBlogService
    {
        Task<Blog> CreateBlog(CreateBlogDTO createBlogDTO);
        Task<IEnumerable<Blog>> getAllBlog();
    }
}
