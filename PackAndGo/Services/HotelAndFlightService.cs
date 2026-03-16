using PackAndGo.DTOs;
using PackAndGo.Enums;
using PackAndGo.ExternalApiServices.Interfaces;
using PackAndGo.Models;
using PackAndGo.Repositories.Interfaces;
using PackAndGo.Services.Interfaces;

namespace PackAndGo.Services
{
    public class HotelAndFlightService : ISearchService
    {
        private readonly IHotelService _hotelService;
        private readonly IFlightService _flightService;
        private readonly IBookingRepository _bookingRepository;

        public HotelAndFlightService(IHotelService hotelService, IFlightService flightService, IBookingRepository bokingRepository)
        {
            _hotelService = hotelService;
            _flightService = flightService;
            _bookingRepository = bokingRepository;
        }

        public async Task<SearchRes> SearchAsync(SearchReq request)
        {
            var options = new List<Option>();

            var hotels = await _hotelService.GetHotelsAsync(request.Destination);
            var flights = await _flightService.GetFlightsAsync(request.DepartureAirport!, request.Destination);

            foreach (var hotel in hotels)
            {
                foreach (var flight in flights)
                {
                    var option = new Option()
                    {
                        HotelCode = hotel.HotelCode.ToString(),
                        FlightCode = flight.FlightCode.ToString(),
                        ArrivalAirport = flight.ArrivalAirport,
                        FromDate = request.FromDate,
                        Price = 1000.50 + 1500.85,
                    };

                    options.Add(option);
                    _bookingRepository.SaveOption(option);
                }
            }

            return new SearchRes() { Options = options };
        }
    }
}
