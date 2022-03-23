using NetFusion.Bootstrap.Plugins;

namespace Examples.MicroserviceTwo.Domain.Plugin
{
    public class DomainPlugin : PluginBase
    {
        public override string PluginId => "05FC3DBD-CF90-4110-B539-4A84EB38C4FA";
        public override PluginTypes PluginType => PluginTypes.AppPlugin;
        public override string Name => "Domain Model Component";
        
        public DomainPlugin()
        {
            Description = "Plugin component containing the Microservice's domain model.";
        }
    }
}