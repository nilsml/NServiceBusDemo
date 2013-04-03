using System;
using Email.Messages.Commands;
using Email.Messages.Events;
using NServiceBus;

namespace Email.Endpoint
{
    public class SendEmailHandler : IHandleMessages<SendEmail>
    {
        private readonly IBus _bus;

        public SendEmailHandler(IBus bus)
        {
            _bus = bus;
        }

        public void Handle(SendEmail message)
        {
            Console.WriteLine("Sending Email to: {0} with subject {1} and body\r\n{2}", message.To,
                                            message.Subject, message.Body);

            _bus.Publish<EmailSentTo>(m =>
                                          {
                                              m.Id = Guid.NewGuid();
                                              m.To = message.To;
                                              m.Subject = message.Subject;
                                              m.Body = message.Body;
                                          }

    );
        }
    }
}