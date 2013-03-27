namespace WebApplication 
{
    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://nservicebus.com/GenericHost.aspx
	*/
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
	    public void Init()
	    {
            Configure.With()
                .RavenSubscriptionStorage()
                .RavenPersistence()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.Contains("Messages") && t.Namespace.EndsWith(".Commands"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.Contains("Messages") && t.Namespace.EndsWith(".Events"));
	    }
    }
}