using NetFusion.Bootstrap.Plugins;
using Examples.MicroserviceOne.Infra.Plugin.Modules;

namespace Examples.MicroserviceOne.Infra.Plugin
{
    public class InfraPlugin : PluginBase
    {
        public override string PluginId => "8281F4B9-B90A-4427-8174-DD109537AC10";
        public override PluginTypes PluginType => PluginTypes.AppPlugin;
        public override string Name => "Infrastructure Application Component";

        public InfraPlugin() {
            AddModule<RepositoryModule>();

            Description = "Plugin component containing the application infrastructure.";
        }
    }
}
