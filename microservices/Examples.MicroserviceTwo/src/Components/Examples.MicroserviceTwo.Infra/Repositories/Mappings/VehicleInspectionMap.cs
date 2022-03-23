using Examples.MicroserviceTwo.Domain.Entities;
using NetFusion.MongoDB;

namespace Examples.MicroserviceTwo.Infra.Repositories.Mappings;

public class VehicleInspectionMap : EntityClassMap<VehicleInspection>
{
    public VehicleInspectionMap()
    {
        CollectionName = "inspection.inquiries";
        AutoMap();
        MapStringPropertyToObjectId(m => m.Id);
    }
}