using System;
using Email.Messages.Events;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using NServiceBus;
using WebApplication.Messages.Events;

namespace WebApplication.Endpoint
{
    public class EmailSentToHandler : IHandleMessages<EmailSentTo>
    {
        private readonly IBus _bus;

        public EmailSentToHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(EmailSentTo message)
        {
            var connection = new HubConnection("http://localhost:49867/");
            var emailHub = connection.CreateHubProxy("EmailHub");

            lock (connection)
            {
                if (connection.State == ConnectionState.Disconnected)
                {
                    connection.Start().Wait();
                }
            }

            Console.WriteLine("Message received! Preparing to send to browser...");
            emailHub.Invoke("Send", new object[] {message.To, message.Subject, message.Body}).ContinueWith(task => Console.WriteLine("Successfully published message to the hub!"));

            _bus.Publish<EmailRead>(m => m.Id = message.Id);
        }
    }

}