using API.Business.DTOs.NotificationDTO;
using API.Business.Shared;
using API.Entities;

namespace API.Business.Repository.IRepository
{
    public interface INotificationRepository : IRepositoryBase<Notification>
    {
        Task<IEnumerable<Notification>> getNotificationByCustomerId(string customerId, NotificationParameter notificationParameter);
       void addNoti(Notification notification);
    }
}
