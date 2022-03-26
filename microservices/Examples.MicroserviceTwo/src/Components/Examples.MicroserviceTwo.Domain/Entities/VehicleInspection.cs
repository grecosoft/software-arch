using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.MicroserviceTwo.Domain.Entities;

public class VehicleInspection
{
    public string Id { get; private set; }
    public string Make { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    
    public Guid InquiryId { get; private set; }
    public VehicleRecall[] Recalls { get; private set; }
    
    public static VehicleInspection ForInquiry(AutoInquiry inquiry)
    {
        return new VehicleInspection
        {
            InquiryId = Guid.NewGuid(),
            Make = inquiry.Make,
            Model = inquiry.Model,
            Year = inquiry.Year,
            Recalls = Array.Empty<VehicleRecall>()
        };
    }

    public void RecordRecalls(IEnumerable<VehicleRecall> recalls)
    {
        Recalls = recalls.ToArray();
    }
}