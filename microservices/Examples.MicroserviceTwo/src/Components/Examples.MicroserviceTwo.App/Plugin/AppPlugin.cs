using NetFusion.Bootstrap.Plugins;
using Examples.MicroserviceTwo.App.Plugin.Modules;

namespace Examples.MicroserviceTwo.App.Plugin
{
    public class AppPlugin : PluginBase
    {
        public override string PluginId => "E4B609C2-6D3B-4BE5-A7C7-3F40DF031C09";
        public override PluginTypes PluginType => PluginTypes.AppPlugin;
        public override string Name => "Application Services Component";

        public AppPlugin()
        {
            AddModule<ServiceModule>();

            Description = "Plugin component containing the Microservice's application services.";
        }   
    }
}