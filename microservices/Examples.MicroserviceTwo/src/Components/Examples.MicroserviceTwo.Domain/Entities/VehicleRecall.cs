namespace Examples.MicroserviceTwo.Domain.Entities;

public class VehicleRecall
{
    public string Manufacturer { get; init; }
    public string CampaignNumber { get; init; }
    public string ActionNumber { get; init; }
    public string ReportedDate { get; init; }
    public string Component { get; init; }
    public string Summary { get; init; }
    public string Consequence { get; init; }
    public string CorrectiveAction { get; init; }
    public string Notes { get; init; }
}