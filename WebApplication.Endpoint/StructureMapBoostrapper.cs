using StructureMap;

namespace WebApplication
{
    internal class StructureMapBootstrapper
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