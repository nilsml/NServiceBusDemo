using Microsoft.AspNet.SignalR;

namespace WebApplication
{
    public class EmailHub : Hub
    {
        public void Send(string to, string subject, string body)
        {
            Clients.All.broadcastMessage(to, subject, body);
        }
    }
}