using API.Entities.Enum;

namespace API.Business.DTOs.NotificationDTO
{
    public class GetNotificationDTO
    {
        public string? Content { get; set; }
        public DateTime Create { get; set; }
        public Watched Watched { get; set; }
        public string? Header { get; set; }

        public string? CustomerID { get; set; }
    }
}
