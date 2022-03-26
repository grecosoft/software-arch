using System;
using System.Collections.Generic;
using Examples.MicroserviceTwo.Domain.Entities;
using NetFusion.Messaging.Types;

namespace Examples.MicroserviceTwo.Domain.Commands;

public class VehicleInquiryCommand : Command
{
    public Guid InquiryId { get; private set; }
    public string Make { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    
    public VehicleInquiryCommand(VehicleInspection inspection)
    {
        InquiryId = inspection.InquiryId;
        Make = inspection.Make;
        Model = inspection.Model;
        Year = inspection.Year;
    }
}

public class VehicleReport : Message
{
    public Guid InquiryId { get; set; }
    public bool HasReportedDamage { get; set; }
    public decimal SuggestedValue { get; set; }
    public int LastReportedMileage { get; set; }
  
    public IEnumerable<VehicleRecall> Recalls { get; set; }
}