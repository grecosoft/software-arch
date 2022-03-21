using NetFusion.Bootstrap.Plugins;

namespace Examples.Probes.Domain.Plugin
{
    public class DomainPlugin : PluginBase
    {
        public override string PluginId => "F4E7F2CA-F1D8-4335-BF1D-62C6A84D4DB8";
        public override PluginTypes PluginType => PluginTypes.AppPlugin;
        public override string Name => "Domain Model Component";
        
        public DomainPlugin()
        {
            Description = "Plugin component containing the Microservice's domain model.";
        }
    }
}