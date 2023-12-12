using API.Business.DTOs.NotificationDTO;
using API.Business.Shared;

namespace API.Business.Services.Interface
{
    public interface INotificationService
    {
        Task<IEnumerable<GetNotificationDTO>> getNotificationByCustomerId(string customerId, NotificationParameter notificationParameter);
    }
}
