using Examples.Probes.WebApi.Plugin;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Bootstrap.Container;

namespace Examples.Probes.WebApi.Controllers
{
    [ApiController, Route("api/pods")]
    public class PodController : ControllerBase
    {
        private readonly ICompositeApp _compositeApp;
        private readonly IHealthCheckModule _healthCheck;
        
        public PodController(
            ICompositeApp compositeApp,
            IHealthCheckModule healthCheck)
        {
            _compositeApp = compositeApp;
            _healthCheck = healthCheck;
        }
        
        [HttpGet("host-name")]
        public IActionResult GetHostName() => Ok(Environment.GetEnvironmentVariable("HOSTNAME"));
        
        [HttpPost("toggle/ready-status")]
        public IActionResult ToggleReadyStatus()
        {
            return Ok(_compositeApp.ToggleReadyStatus());
        }
        
        [HttpPost("toggle/health-status")]
        public IActionResult ToggleHealthStatus()
        {
            return Ok(_healthCheck.ToggleHealthStatus());
        }
        
    }
}
