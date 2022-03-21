using Examples.Probes.WebApi.Models;
using NetFusion.Bootstrap.Plugins;

namespace Examples.Probes.WebApi.Plugin
{
    public class WebApiPlugin : PluginBase
    {
        public const string HostId = "89A33006-5E86-43AB-AA99-2BBFDFA6DA77";
        public const string HostName = "examples-probes";

        public override PluginTypes PluginType => PluginTypes.HostPlugin;
        public override string PluginId => HostId;
        public override string Name => HostName;
        
        public WebApiPlugin()
        {
            AddModule<HealthCheckModule>();
            
            Description = "WebApi host exposing REST/HAL based Web API.";
        }
    }
}