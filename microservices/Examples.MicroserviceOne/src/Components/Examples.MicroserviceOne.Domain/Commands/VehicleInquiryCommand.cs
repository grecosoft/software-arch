using System.Collections.Generic;
using Examples.MicroserviceOne.Domain.Entities;
using NetFusion.Messaging.Types;

namespace Examples.MicroserviceOne.Domain.Commands;

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