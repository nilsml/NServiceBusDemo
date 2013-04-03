using System;

namespace Email.Messages.Events
{
    public interface EmailSentTo
    {
       string To { get; set; }
       string Subject { get; set; }
       string Body { get; set; }
       Guid Id { get; set; }
    }
}