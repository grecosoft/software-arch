using System;
using System.Linq;
using System.Threading.Tasks;
using Examples.MicroserviceOne.App.Adapters;
using Examples.MicroserviceOne.Domain.Commands;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;
using NetFusion.RabbitMQ.Subscriber;

namespace Examples.MicroserviceOne.App.Handlers;

public class VehicleInquiryHandler : IMessageConsumer
{
    private readonly IRecallAdapter _recallAdapter;
    
    public VehicleInquiryHandler(IRecallAdapter recallAdapter)
    {
        _recallAdapter = recallAdapter;
    }
    
    [WorkQueue("testBus", "VehicleInquiry")]
    public async Task<VehicleReport> CheckForRecalls(VehicleInquiryCommand inquiry)
    {
        Console.WriteLine(inquiry.ToIndentedJson());

        // Call NHTSA Web-Api to determine if the vehicle has any recalls.
        var recalls = await _recallAdapter.ReadRecallsAsync(inquiry.Make, inquiry.Model, inquiry.Year)
            .ToArrayAsync();

        return new VehicleReport
        {
            InquiryId = inquiry.InquiryId,
            Recalls = recalls
        };
    }
}