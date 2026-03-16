using PackAndGo.Models;

namespace PackAndGo.ExternalApiServices.Interfaces
{
    public interface IFlightService
    {
        Task<List<Flight>> GetFlightsAsync(string departureAirport, string arrivalAirport);
    }
}
