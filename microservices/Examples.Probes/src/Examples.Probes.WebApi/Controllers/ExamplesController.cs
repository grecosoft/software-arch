using Microsoft.AspNetCore.Mvc;
using NetFusion.Bootstrap.Container;

namespace Examples.Probes.WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class ExamplesController : ControllerBase
{
    private readonly ICompositeApp _compositeApp;
    
    public ExamplesController(ICompositeApp compositeApp)
    {
        _compositeApp = compositeApp;
    }

    [HttpGet("host-plugin")]
    public IActionResult GetHostPlugin() => Ok(_compositeApp.HostPlugin);
}