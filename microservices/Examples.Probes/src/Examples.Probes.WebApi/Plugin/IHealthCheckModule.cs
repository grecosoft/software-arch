using NetFusion.Bootstrap.Plugins;

namespace Examples.Probes.WebApi.Plugin
{
    public interface IHealthCheckModule : IPluginModuleService
    {
        string ToggleHealthStatus();
    }
}