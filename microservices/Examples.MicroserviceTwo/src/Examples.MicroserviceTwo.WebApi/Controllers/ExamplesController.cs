using Examples.MicroserviceTwo.App.Repositories;
using Examples.MicroserviceTwo.Domain.Commands;
using Examples.MicroserviceTwo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Messaging;

namespace Examples.MicroserviceTwo.WebApi.Controllers;

[ApiController, Route("api/[controller]")]
public class ExamplesController : ControllerBase
{
    private readonly IMessagingService _messaging;
    private readonly IVehicleInspectionRepository _inspectionRepo;
    
    public ExamplesController(
        IMessagingService messaging,
        IVehicleInspectionRepository inspectionRepo)
    {
        _messaging = messaging;
        _inspectionRepo = inspectionRepo;
    }

    [HttpPost("test")]
    public async Task<IActionResult> Test()
    {
        var command = new VehicleInquiryCommand
        {
            Make = "acura",
            Model = "rdx",
            Year = 2012
        };

        var inspection = new VehicleInspection
        {
            Make = command.Make,
            Model = command.Model,
            Year = command.Year
        };

        await _inspectionRepo.Add(inspection);
        await _messaging.SendAsync(command);
        
        return Ok();
    }
}