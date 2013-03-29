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

            do
            {
                Console.WriteLine("Press a key to send a message.." + Environment.NewLine + "Press Q to end the program.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Q)
                    return;

                bus.Send("Email.Endpoint", new SendEmail("some.person@domain.com", "Hello there!", string.Format("The time is now {0}!", DateTime.Now.ToShortTimeString())));
            } while (true);

        }
    }
}
