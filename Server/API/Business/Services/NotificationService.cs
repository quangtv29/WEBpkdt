using API.Business.DTOs.NotificationDTO;
using API.Business.Repository.IRepository;
using API.Business.Services.Interface;
using API.Business.Shared;
using API.Entities;
using AutoMapper;

namespace API.Business.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IRepositoryManager _repo;
        private readonly IMapper _mapper;

        public NotificationService(IRepositoryManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetNotificationDTO>> getNotificationByCustomerId(string customerId, NotificationParameter notificationParameter)
        {
            var result = await _repo.Notification.getNotificationByCustomerId(customerId, notificationParameter);

            return _mapper.Map<IEnumerable<GetNotificationDTO>>(result);
        }

        public async Task<Notification> createNoti (CreateNotificationDTO createNotificationDTO)
        {
            var noti = _mapper.Map<Notification>(createNotificationDTO);
              _repo.Notification.addNoti(noti);
            await _repo.SaveAsync();
            return noti;


        }
    }
}
