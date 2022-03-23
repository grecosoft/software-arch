using NetFusion.Bootstrap.Plugins;
using Examples.MicroserviceOne.App.Plugin.Modules;

namespace Examples.MicroserviceOne.App.Plugin
{
    public class AppPlugin : PluginBase
    {
        public override string PluginId => "7516366F-D45A-411A-A7DC-3FC2F141B08D";
        public override PluginTypes PluginType => PluginTypes.AppPlugin;
        public override string Name => "Application Services Component";

        public AppPlugin()
        {
            AddModule<ServiceModule>();

            Description = "Plugin component containing the Microservice's application services.";
        }   
    }
}