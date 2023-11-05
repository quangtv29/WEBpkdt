using API.Business.DTOs.FeedbackDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Business.Shared;
using API.Entities;
using AutoMapper;

namespace API.Business.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public FeedbackService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Feedback> createFeedback(CreateFeedbackDTO feedback)
        {
            var result = _mapper.Map<Feedback>(feedback);
            _repo.Feedback.CreateFeedback(result);
             await _repo.SaveAsync();
            return result;
        }

        public async Task<IEnumerable<GetFeedbackByProductDTO>> getFeedbackByProduct(Guid? productId, FeedbackParameters feedbackParameters)
        {
            var result = await _repo.Feedback.getFeedbackByProduct(productId, feedbackParameters);
            return _mapper.Map<IEnumerable<GetFeedbackByProductDTO>>(result);
        }
    }
}
