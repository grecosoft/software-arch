using NetFusion.Bootstrap.Plugins;
using Examples.Probes.Infra.Plugin.Modules;

namespace Examples.Probes.Infra.Plugin
{
    public class InfraPlugin : PluginBase
    {
        public override string PluginId => "949B848E-50DF-4069-99E6-65310ED0A40B";
        public override PluginTypes PluginType => PluginTypes.AppPlugin;
        public override string Name => "Infrastructure Application Component";

        public InfraPlugin() {
            AddModule<RepositoryModule>();

            Description = "Plugin component containing the application infrastructure.";
        }
    }
}
