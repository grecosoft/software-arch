using System.Collections.Generic;
using Examples.MicroserviceOne.Domain.Entities;

namespace Examples.MicroserviceOne.App.Adapters
{
    /// <summary>
    /// Implements an adapter querying an external web-api for automobile recalls.
    /// </summary>
    public interface IRecallAdapter
    {
        /// <summary>
        /// Returns list of vehicle recalls.
        /// </summary>
        /// <param name="make">The make of the automobile.</param>
        /// <param name="model">The model of the automobile.</param>
        /// <param name="year">The year of the automobile.</param>
        /// <returns>List of recalls for the specified automobile.</returns>
        IAsyncEnumerable<VehicleRecall> ReadRecallsAsync(string make, string model, int year);
    }
}