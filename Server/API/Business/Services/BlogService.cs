using API.Business.DTOs.BlogDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using API.Business.Helper;
using Microsoft.Extensions.Options;

namespace API.Business.Services
{
    public class BlogService : IBlogService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        private readonly Cloudinary _cloudinary;
        private readonly IConfiguration _configuration;

        public BlogService(IRepositoryManager repo, IMapper mapper, IOptions<CloudinarySettings> config, IConfiguration configuration)
        {
            _configuration = configuration;
            _repo = repo;
            _mapper = mapper;
            var account = new Account(
           _configuration.GetValue<string>("CloudinarySettings:CloudName"),
           _configuration.GetValue<string>("CloudinarySettings:ApiKey"),
           _configuration.GetValue<string>("CloudinarySettings:ApiSecret"));
            _cloudinary = new Cloudinary(account);
        }

        public async Task<Blog> CreateBlog (CreateBlogDTO createBlogDTO)
        {
            var blog = _mapper.Map<Blog>(createBlogDTO);
            if (createBlogDTO.Image != null)
            {
                string imagePath = await SaveImage(createBlogDTO.Image);
                blog.Image = imagePath;
            }    
            _repo.Blog.CreateBlog(blog);
            await _repo.SaveAsync();
            return blog;
        }
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            var publicId = Guid.NewGuid().ToString();
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(imageFile.FileName, imageFile.OpenReadStream()),
                PublicId = publicId
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);


            var imageUrl = uploadResult.SecureUrl.ToString();

            return imageUrl;
        }
        public async Task<IEnumerable<Blog>> getAllBlog ()
        {
            var result = await _repo.Blog.GetAll(false).Where(p => p.isDelete == false)
                .ToListAsync();
            foreach(var blog in result)
            {
                blog.FormatDate = blog.Create.ToString("dd/MM/yyyy HH:mm:ss");
                blog.LastChange = blog.LastModificationTime.ToString("dd/MM/yyyy HH:mm:ss");
            }
            return result;
        }
    }
}
