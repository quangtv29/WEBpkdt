using API.Business.DTOs.FeedbackDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Business.Shared;
using API.Entities;
using AutoMapper;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using API.Business.Helper;
using Microsoft.Extensions.Options;

namespace API.Business.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;
        public readonly Cloudinary _cloudinary;
        private readonly IConfiguration _configuration;


        public FeedbackService(IRepositoryManager repo, IMapper mapper, IOptions<CloudinarySettings> config, IConfiguration configuration)
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

        public async Task<Feedback> createFeedback(CreateFeedbackDTO feedback)
        {
            var order = await _repo.OrderDetail.GetOrderDetailById(feedback.OrderDetailId);
           
            if (order.isSave)
            {
                if (feedback.file == null || feedback.file.Length == 0)
                {
                    order.isSave = false;
                    var result = _mapper.Map<Feedback>(feedback);
                    _repo.Feedback.CreateFeedback(result);
                    await _repo.SaveAsync();
                    return result;
                }
                else
                {
                    string imagePath = await SaveImage(feedback.file);
                    order.isSave = false;
                    var result = _mapper.Map<Feedback>(feedback);
                    result.Image = imagePath;
                    _repo.Feedback.CreateFeedback(result);
                    await _repo.SaveAsync();
                    return result;
                }
            }
            return null;

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
        public async Task<IEnumerable<Feedback>> getFeedbackByProduct(Guid? productId, FeedbackParameters feedbackParameters,int star)
        {
            var result = await _repo.Feedback.getFeedbackByProduct(productId, feedbackParameters,star);
            return result;
        }
    }
}
