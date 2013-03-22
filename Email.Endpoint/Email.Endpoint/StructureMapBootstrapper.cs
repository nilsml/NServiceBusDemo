using StructureMap;

namespace Email.Endpoint
{
    class StructureMapBootstrapper
    {
        public static void Bootstrap()
        {
            ObjectFactory.Initialize(conf => conf.Scan(scan =>
                                                           {
                                                               scan.TheCallingAssembly();
                                                               scan.WithDefaultConventions();
                                                           }));
        }
    }
}
