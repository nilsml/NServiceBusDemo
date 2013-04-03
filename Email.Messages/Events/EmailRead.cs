using System;

namespace Email.Messages.Events
{
    public interface EmailRead
    {
        Guid Id { get; set; }
    }
}