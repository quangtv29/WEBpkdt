using API.Business.DTOs.NotificationDTO;
using API.Business.Repository.IRepository;
using API.Business.Shared;
using API.Database;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Business.Repository
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(DataContext db) : base(db)
        {
        }

        public async Task<IEnumerable<Notification>> getNotificationByCustomerId(string customerId, NotificationParameter notificationParameter)
        {
            var result = await GetAllByCondition(p => p.CustomerID == customerId, false)
                .Where(p => p.isDelete == false)
                .Skip((notificationParameter.PageNumber - 1) * notificationParameter.PageSize)
                .Take(notificationParameter.PageSize)
                .ToListAsync();
            return result;
        }
    }
}
