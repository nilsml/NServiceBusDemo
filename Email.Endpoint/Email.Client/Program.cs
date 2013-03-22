using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Email.Messages.Commands;

namespace Email.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = NServiceBusBootstrapper.Run();
            Console.WriteLine("Press a key to send a message..");
            Console.ReadKey();

            bus.Send("Email.Endpoint", new SendEmail("some.person@domain.com", "Hello there!", "This is a message body..."));
        }
    }
}
