using NetFusion.Bootstrap.Plugins;

namespace Examples.MicroserviceTwo.WebApi.Plugin
{
    public class WebApiPlugin : PluginBase
    {
        public const string HostId = "3CACA93E-8DBF-4538-A685-0A228BF2BC36";
        public const string HostName = "examples-microservicetwo";

        public override PluginTypes PluginType => PluginTypes.HostPlugin;
        public override string PluginId => HostId;
        public override string Name => HostName;
        
        public WebApiPlugin()
        {
            Description = "WebApi host exposing REST/HAL based Web API.";
        }
    }
}