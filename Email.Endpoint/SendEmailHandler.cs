using System;
using Email.Messages.Commands;
using NServiceBus;

namespace Email.Endpoint
{
    public class SendEmailHandler : IHandleMessages<SendEmail>
    {
        public void Handle(SendEmail message)
        {
            Console.WriteLine(string.Format("Sending Email to: {0} with subject {1} and body\r\n{2}", message.To, message.Subject, message.Body));
        }
    }
}