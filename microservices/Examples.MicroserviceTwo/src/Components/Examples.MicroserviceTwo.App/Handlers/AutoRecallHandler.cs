using System.Threading.Tasks;
using Examples.MicroserviceTwo.App.Repositories;
using Examples.MicroserviceTwo.Domain.Commands;
using Examples.MicroserviceTwo.Domain.Entities;
using Microsoft.Extensions.Logging;
using NetFusion.Messaging;
using NetFusion.RabbitMQ.Subscriber;

namespace Examples.MicroserviceTwo.App.Handlers;

public class AutoRecallHandler : IMessageConsumer
{
    private readonly ILogger<AutoRecallHandler> _logger;
    private readonly IVehicleInspectionRepository _inspectionRepo;
    
    public AutoRecallHandler(
        ILogger<AutoRecallHandler> logger,
        IVehicleInspectionRepository inspectionRepo)
    {
        _logger = logger;
        _inspectionRepo = inspectionRepo;
    }
    
    [WorkQueue("testBus", "VehicleInquiryResults")]
    public async Task OnValidationResult(VehicleReport result)
    {
        VehicleInspection inspection = await _inspectionRepo.GetByInquiry(result.InquiryId);

        if (inspection == null)
        {
            _logger.LogError("Received result for inquiry: {InquiryId} with no record", result.InquiryId);
            return;
        }
        
        inspection.RecordRecalls(result.Recalls);
        await _inspectionRepo.Replace(inspection);
    }
}