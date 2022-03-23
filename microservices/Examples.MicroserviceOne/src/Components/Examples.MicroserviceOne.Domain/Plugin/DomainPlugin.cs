using NetFusion.Bootstrap.Plugins;

namespace Examples.MicroserviceOne.Domain.Plugin
{
    public class DomainPlugin : PluginBase
    {
        public override string PluginId => "5F7DE984-56AF-4052-95BB-FA62620BA836";
        public override PluginTypes PluginType => PluginTypes.AppPlugin;
        public override string Name => "Domain Model Component";
        
        public DomainPlugin()
        {
            Description = "Plugin component containing the Microservice's domain model.";
        }
    }
}