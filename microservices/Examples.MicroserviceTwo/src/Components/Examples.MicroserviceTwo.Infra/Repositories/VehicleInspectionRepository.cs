using System;
using System.Threading.Tasks;
using Examples.MicroserviceTwo.App.Repositories;
using Examples.MicroserviceTwo.Domain.Entities;
using MongoDB.Driver;
using NetFusion.MongoDB;

namespace Examples.MicroserviceTwo.Infra.Repositories;

public class VehicleInspectionRepository : IVehicleInspectionRepository
{
    private IMongoCollection<VehicleInspection> InspectionColl { get; }

    public VehicleInspectionRepository(IMongoDbClient<VehiclesDb> vehiclesDb)
    {
        InspectionColl = vehiclesDb.GetCollection<VehicleInspection>();
    }

    public async Task<string> Add(VehicleInspection inspection)
    {
        await InspectionColl.InsertOneAsync(inspection);
        return inspection.Id;
    }

    public async Task<VehicleInspection> GetByInquiry(Guid inquiryId)
    {
        var result = await InspectionColl.FindAsync(f => f.InquiryId == inquiryId);
        var inspection = await result.FirstOrDefaultAsync();

        if (inspection == null)
        {
            
        }

        return inspection;
    }
    
    public async Task Replace(VehicleInspection inspection)
    {
        await InspectionColl.FindOneAndReplaceAsync(f => f.Id == inspection.Id, inspection);
    }
}