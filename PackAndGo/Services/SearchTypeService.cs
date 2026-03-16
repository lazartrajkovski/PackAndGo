using PackAndGo.DTOs;
using PackAndGo.Services.Interfaces;

namespace PackAndGo.Services
{
    public class SearchTypeService : ISearchTypeService
    {
        private readonly HotelOnlyService _hotelOnlyService;
        private readonly HotelAndFlightService _hotelAndFlightService;
        private readonly LastMinuteHotelService _lastMinuteHotelService;

        public SearchTypeService(HotelOnlyService hotelOnlyService, HotelAndFlightService hotelAndFlightService, LastMinuteHotelService lastMinuteHotelService)
        {
            _hotelOnlyService = hotelOnlyService;
            _hotelAndFlightService = hotelAndFlightService;
            _lastMinuteHotelService = lastMinuteHotelService;
        }

        public async Task<SearchRes> SearchTypeAsync(SearchReq request)
        {
            if (request.FromDate <= DateTime.UtcNow.AddDays(45) && string.IsNullOrEmpty(request.DepartureAirport))
            {
                return await _lastMinuteHotelService.SearchAsync(request);
            }
            else if (string.IsNullOrEmpty(request.DepartureAirport))
            {
                return await _hotelOnlyService.SearchAsync(request);
            }
            else
            {
                return await _hotelAndFlightService.SearchAsync(request);
            }
        }
    }
}
