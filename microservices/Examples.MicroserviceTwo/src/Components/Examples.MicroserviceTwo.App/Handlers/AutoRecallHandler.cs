using System;
using Examples.MicroserviceTwo.Domain.Commands;
using NetFusion.Common.Extensions;
using NetFusion.Messaging;
using NetFusion.RabbitMQ.Subscriber;

namespace Examples.MicroserviceTwo.App.Handlers;

public class AutoRecallHandler : IMessageConsumer
{
    [WorkQueue("testBus", "VehicleInquiryResults")]
    public void OnValidationResult(VehicleReport result)
    {
        Console.WriteLine(result.ToIndentedJson());
    }
}