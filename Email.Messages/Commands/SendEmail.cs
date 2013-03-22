namespace Email.Messages.Commands
{
    public class SendEmail
    {
        public string To { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }

        public SendEmail(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}