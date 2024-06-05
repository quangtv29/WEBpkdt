using API.Business.DTOs.PhotoDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Entities;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IRepositoryManager _repo;
        private readonly Cloudinary _cloudinary;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public PhotoService(IRepositoryManager repo, IConfiguration configuration,IMapper mapper)
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

        public async Task CreatePhoto(CreatePhotoDTO pt)
        {
           
                if (pt == null) throw new ArgumentNullException();
                if (pt.Image == null || pt.Image.Length == 0)
                {
                    throw new Exception("Không có ảnh");
                }
                var pro = _mapper.Map<Photo>(pt);
                string imagePath = await SaveImage(pt.Image);
                pro.Image = imagePath;
                _repo.Photo.CreatePhoto(pro);
                await _repo.SaveAsync();
            
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

        public async Task<IEnumerable<Photo>> getPhotoByProduct (Guid Id)
        {
            var result = await _repo.Photo.GetAllByCondition(p => p.ProductId == Id, false).Where(p => p.isDelete == false).ToListAsync();
            return result;
        }
    }
}
