using NetFusion.Bootstrap.Plugins;
using Examples.MicroserviceTwo.Infra.Plugin.Modules;

namespace Examples.MicroserviceTwo.Infra.Plugin
{
    public class InfraPlugin : PluginBase
    {
        public override string PluginId => "DDC42093-7A87-4E57-8F64-544F3DDC24D1";
        public override PluginTypes PluginType => PluginTypes.AppPlugin;
        public override string Name => "Infrastructure Application Component";

        public InfraPlugin() {
            AddModule<RepositoryModule>();

            Description = "Plugin component containing the application infrastructure.";
        }
    }
}
