using System.Threading.Tasks;
using Examples.MicroserviceTwo.App.Repositories;
using Examples.MicroserviceTwo.Domain.Commands;
using Examples.MicroserviceTwo.Domain.Entities;
using Examples.MicroserviceTwo.Domain.Services;
using NetFusion.Messaging;

namespace Examples.MicroserviceTwo.App.Services;

public class AutoInquiryService : IAutoInquiryService
{
    private readonly IMessagingService _messaging;
    private readonly IVehicleInspectionRepository _inspectionRepo;
    
    public AutoInquiryService(
        IMessagingService messaging,
        IVehicleInspectionRepository inspectionRepo)
    {
        _messaging = messaging;
        _inspectionRepo = inspectionRepo;
    }

    public async Task<VehicleInspection> ProcessInquiry(AutoInquiry inquiry)
    {
        var inspection = VehicleInspection.ForInquiry(inquiry);

        await _inspectionRepo.Add(inspection);

        var inquiryCommand = new VehicleInquiryCommand(inspection);
        await _messaging.SendAsync(inquiryCommand);

        return inspection;
    }
}