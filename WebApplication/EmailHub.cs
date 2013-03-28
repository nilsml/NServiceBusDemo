using System.Diagnostics;
using Microsoft.AspNet.SignalR;

namespace WebApplication
{
    public class EmailHub : Hub
    {
        public override System.Threading.Tasks.Task OnConnected()
        {
            Debug.WriteLine("Client connected!");
            return base.OnConnected();
        }

        public void Send(string to, string subject, string body)
        {
            Clients.All.emailReceived(to, subject, body);
        }

        public void Connected()
        {
            Debug.WriteLine("Connected");
            //Clients.All.emailReceived("To", "Subject", "Body");
        }
    }
}