using NetFusion.MongoDB.Settings;
using NetFusion.Settings;

namespace Examples.MicroserviceTwo.Infra.Repositories;

[ConfigurationSection("netfusion:mongoDB:vehiclesDb")]
public class VehiclesDb : MongoSettings
{
    
}