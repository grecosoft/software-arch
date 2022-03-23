using Examples.MicroserviceTwo.Domain.Commands;
using NetFusion.RabbitMQ.Publisher;

namespace Examples.MicroserviceTwo.Infra;

public class ExchangeRegistry : ExchangeRegistryBase
{
    protected override void OnRegister()
    {
        DefineWorkQueueWithResponse<VehicleInquiryCommand>("VehicleInquiry", "testBus", "VehicleInquiryResults");
    }
}