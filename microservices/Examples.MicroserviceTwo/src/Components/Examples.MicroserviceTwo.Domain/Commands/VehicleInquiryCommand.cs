using System.Collections.Generic;
using Examples.MicroserviceTwo.Domain.Entities;
using NetFusion.Messaging.Types;

namespace Examples.MicroserviceTwo.Domain.Commands;

public class VehicleInquiryCommand : Command
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
}

public class VehicleReport : Message
{
    public bool HasReportedDamage { get; set; }
    public decimal SuggestedValue { get; set; }
    public int LastReportedMileage { get; set; }
  
    public IEnumerable<VehicleRecall> Recalls { get; set; }
}