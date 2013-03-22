using NServiceBus;

namespace Email.Client
{
    public class NServiceBusBootstrapper
    {
        public static IBus Run()
        {
                return Configure.With()
                                .DefineEndpointName("Email.Client")
                                .Log4Net()
                                .DefaultBuilder()
                                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.Contains(".Messages") && t.Namespace.EndsWith(".Commands"))
                                .XmlSerializer()
                                .MsmqTransport()
                                .IsTransactional(false)
                                .PurgeOnStartup(false)
                                .UnicastBus()
                                .ImpersonateSender(false)
                                .SendOnly();
        } 
    }
}