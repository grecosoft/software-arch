using NetFusion.Bootstrap.Plugins;
using Examples.Probes.App.Plugin.Modules;

namespace Examples.Probes.App.Plugin
{
    public class AppPlugin : PluginBase
    {
        public override string PluginId => "2881BE67-AB1A-4C47-8D0E-999DD01B98AA";
        public override PluginTypes PluginType => PluginTypes.AppPlugin;
        public override string Name => "Application Services Component";

        public AppPlugin()
        {
            AddModule<ServiceModule>();

            Description = "Plugin component containing the Microservice's application services.";
        }   
    }
}