using Microsoft.Extensions.Options;
using PackAndGo.Configuration;
using PackAndGo.ExternalApiServices.Interfaces;
using PackAndGo.Models;
using System.Text.Json;

namespace PackAndGo.ExternalApiServices
{
    public class HotelService : IHotelService
    {
        private readonly HttpClient _httpClient;
        private readonly ExternalApiSettings _settings;

        public HotelService(HttpClient httpClient, IOptions<ExternalApiSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<List<Hotel>> GetHotelsAsync(string destinationCode)
        {
            var url = $"{_settings.HotelsUrl}?destinationCode={destinationCode}";
            var response = await _httpClient.GetStringAsync(url);
            List<Hotel> hotels = JsonSerializer.Deserialize<List<Hotel>>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<Hotel>();

            return hotels;
        }
    }
}
