namespace Examples.MicroserviceTwo.Domain.Entities;

public class VehicleInspection
{
    public string Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public VehicleRecall[] Recalls { get; set; }
}