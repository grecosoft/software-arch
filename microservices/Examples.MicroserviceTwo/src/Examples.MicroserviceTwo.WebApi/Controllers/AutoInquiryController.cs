using Examples.MicroserviceTwo.App.Repositories;
using Examples.MicroserviceTwo.Domain.Commands;
using Examples.MicroserviceTwo.Domain.Entities;
using Examples.MicroserviceTwo.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using NetFusion.Messaging;
using NetFusion.Messaging.Types.Attributes;

namespace Examples.MicroserviceTwo.WebApi.Controllers;

[ApiController, Route("api/auto/inquiries")]
public class AutoController : ControllerBase
{
    private readonly IAutoInquiryService _autoInquiry;
    private readonly IVehicleInspectionRepository _inspectionRepo;
    
    public AutoController(
        IAutoInquiryService autoInquiry,
        IVehicleInspectionRepository inspectionRepo)
    {
        _autoInquiry = autoInquiry;
        _inspectionRepo = inspectionRepo;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitInquiry(AutoInquiry inquiry)
    {
        var inspection = await _autoInquiry.ProcessInquiry(inquiry);
        return Ok(inspection.InquiryId);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetInquiry(Guid id)
    {
        return Ok(await _inspectionRepo.GetByInquiry(id));
    }
}