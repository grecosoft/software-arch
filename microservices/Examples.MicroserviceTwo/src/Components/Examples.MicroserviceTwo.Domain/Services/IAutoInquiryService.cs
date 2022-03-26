using System.Threading.Tasks;
using Examples.MicroserviceTwo.Domain.Entities;

namespace Examples.MicroserviceTwo.Domain.Services;

public interface IAutoInquiryService
{
    Task<VehicleInspection> ProcessInquiry(AutoInquiry inquiry);
}