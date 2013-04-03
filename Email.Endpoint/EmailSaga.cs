using System;
using Email.Messages.Events;
using NServiceBus;
using NServiceBus.Saga;
using WebApplication.Messages.Events;

namespace Email.Endpoint
{
    public class EmailSaga : Saga<SagaData>, IAmStartedByMessages<EmailSentTo>, IHandleMessages<EmailRead>
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<EmailSentTo>(s => s.Id, m => m.Id);
            ConfigureMapping<EmailRead>(s => s.Id, m => m.Id);
        }

        public void Handle(EmailSentTo message)
        {
            Data.Id = message.Id;
        }

        public void Handle(EmailRead message)
        {
            // Do something wicked...
            MarkAsComplete();
        }
    }

    public class SagaData : ISagaEntity
    {
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }
    }
}