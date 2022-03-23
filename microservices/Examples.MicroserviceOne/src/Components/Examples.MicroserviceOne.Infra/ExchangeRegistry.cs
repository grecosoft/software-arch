using Examples.MicroserviceOne.Domain.Commands;
using NetFusion.RabbitMQ.Publisher;

namespace Examples.MicroserviceOne.Infra;

public class ExchangeRegistry : ExchangeRegistryBase
{
    protected override void OnRegister()
    {
        DefineWorkQueue<VehicleInquiryCommand>("VehicleInquiry", "testBus");
    }
}