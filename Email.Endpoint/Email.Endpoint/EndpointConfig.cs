namespace Email.Endpoint 
{
    using NServiceBus;
    
	public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
	    public void Init()
	    {
            StructureMapBootstrapper.Bootstrap();
            Configure.With()
                .StructureMapBuilder()
                .RavenSubscriptionStorage()
                .RavenPersistence()
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.Contains("Messages") && t.Namespace.EndsWith(".Commands"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.Contains("Messages") && t.Namespace.EndsWith(".Events"));
	    }
    }
}