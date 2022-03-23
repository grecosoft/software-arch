using System.Threading.Tasks;
using Examples.MicroserviceTwo.Domain.Entities;

namespace Examples.MicroserviceTwo.App.Repositories;

public interface IVehicleInspectionRepository
{
    Task<string> Add(VehicleInspection inspection);
    Task<VehicleInspection> Find(string id);
    Task Replace(VehicleInspection inspection);
}