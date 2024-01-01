using API.Business.DTOs.NotificationDTO;
using API.Business.Shared;
using API.Entities;

namespace API.Business.Services.Interface
{
    public interface INotificationService
    {
        Task<IEnumerable<Notification>> getNotificationByCustomerId(string customerId, NotificationParameter notificationParameter);
        Task<Notification> createNoti(CreateNotificationDTO createNotificationDTO);
        Task<Notification> updateNoti(Guid? id);
    }
}
