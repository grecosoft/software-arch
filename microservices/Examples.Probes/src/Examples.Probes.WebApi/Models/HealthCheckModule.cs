using Examples.Probes.WebApi.Plugin;
using NetFusion.Bootstrap.Health;
using NetFusion.Bootstrap.Plugins;

namespace Examples.Probes.WebApi.Models
{
    public class HealthCheckModule : PluginModule,
        IHealthCheckModule,
        IModuleHealthCheck
    {
        private HealthCheckStatusType _currentStatus = HealthCheckStatusType.Healthy;
        
        public string ToggleHealthStatus()
        {
            _currentStatus = _currentStatus == HealthCheckStatusType.Healthy
                ? HealthCheckStatusType.Unhealthy
                : HealthCheckStatusType.Healthy;

            return _currentStatus.ToString();
        }
        
        public Task CheckModuleAspectsAsync(ModuleHealthCheck healthCheck)
        {
            if (_currentStatus == HealthCheckStatusType.Healthy)
            {
                healthCheck.RecordAspect(HealthAspectCheck.ForHealthy("CONN", "Active"));
                return Task.CompletedTask;
            }
            
            healthCheck.RecordAspect(HealthAspectCheck.ForUnhealthy("CONN", "Inactive"));
            return Task.CompletedTask;
        }
    }
}