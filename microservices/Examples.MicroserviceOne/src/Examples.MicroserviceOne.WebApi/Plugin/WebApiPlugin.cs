using NetFusion.Bootstrap.Plugins;

namespace Examples.MicroserviceOne.WebApi.Plugin
{
    public class WebApiPlugin : PluginBase
    {
        public const string HostId = "974165F3-D0D3-447F-81CD-FEA43CE8A955";
        public const string HostName = "examples-microserviceone";

        public override PluginTypes PluginType => PluginTypes.HostPlugin;
        public override string PluginId => HostId;
        public override string Name => HostName;
        
        public WebApiPlugin()
        {
            Description = "WebApi host exposing REST/HAL based Web API.";
        }
    }
}