using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class NotificationHub : Hub
    {
        public async Task SendNotification (string message)
        {
            await Clients.All.SendAsync(message);
        }
    }
}
