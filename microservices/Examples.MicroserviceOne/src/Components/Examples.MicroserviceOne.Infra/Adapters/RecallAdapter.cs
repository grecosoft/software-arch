using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Examples.MicroserviceOne.App.Adapters;
using Examples.MicroserviceOne.Domain.Entities;
using Microsoft.AspNetCore.WebUtilities;

namespace Examples.MicroserviceOne.Infra.Adapters
{
    /// <summary>
    /// An adapter calling an external provider of vehicle recall information.
    /// </summary>
    public class RecallAdapter : IRecallAdapter
    {
        private readonly HttpClient _httpClient;
        
        public RecallAdapter(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async IAsyncEnumerable<VehicleRecall> ReadRecallsAsync(string make, string model, int year)
        {
            var responseMsg = await GetRecalls(make, model, year.ToString());
            
            await using var responseStream = await responseMsg.Content.ReadAsStreamAsync();
            using var jsonDoc = await JsonDocument.ParseAsync(responseStream);
            
            foreach (JsonElement recallElem in jsonDoc.RootElement.GetProperty("results").EnumerateArray())
            {
                yield return new VehicleRecall
                {
                    Manufacturer = recallElem.ReadStringProp("Manufacturer"),
                    Component = recallElem.ReadStringProp("Component"),
                    Consequence = recallElem.ReadStringProp("Conequence"),
                    Notes = recallElem.ReadStringProp("Notes"),
                    Summary = recallElem.ReadStringProp("Summary"),
                    ActionNumber = recallElem.ReadStringProp("NHTSAActionNumber"),
                    CampaignNumber = recallElem.ReadStringProp("NHTSACampaignNumber"),
                    CorrectiveAction = recallElem.ReadStringProp("Remedy"),
                    ReportedDate = recallElem.ReadStringProp("ReportReceivedDate")
                };
            }
        }

        private async Task<HttpResponseMessage> GetRecalls(string make, string model, string year)
        {
            var queryParams = new Dictionary<string, string>
            {
                ["make"] = make,
                ["model"] = model,
                ["modelYear"] = year
            };
            
            var responseMsg = await _httpClient.GetAsync(
                QueryHelpers.AddQueryString("/recalls/recallsByVehicle", queryParams));

            responseMsg.EnsureSuccessStatusCode();
            return responseMsg;
        }
    }
}