using Microsoft.Extensions.Options;
using PackAndGo.Configuration;
using PackAndGo.ExternalApiServices.Interfaces;
using PackAndGo.Models;
using System.Text.Json;

namespace PackAndGo.ExternalApiServices
{
    public class FlightService : IFlightService
    {
        private readonly HttpClient _httpClient;
        private readonly ExternalApiSettings _settings;
        
        public FlightService(HttpClient httpClient, IOptions<ExternalApiSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<List<Flight>> GetFlightsAsync(string departureAirport, string arrivalAirport)
        {
            var url = $"{_settings.FlightsUrl}?departureAirport={departureAirport}&arrivalAirport={arrivalAirport}";
            var response = await _httpClient.GetStringAsync(url);
            List<Flight> flights = JsonSerializer.Deserialize<List<Flight>>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<Flight>();

            return flights;
        }
    }
}
