using PackAndGo.DTOs;
using PackAndGo.Enums;
using PackAndGo.ExternalApiServices.Interfaces;
using PackAndGo.Models;
using PackAndGo.Repositories.Interfaces;
using PackAndGo.Services.Interfaces;

namespace PackAndGo.Services
{
    public class LastMinuteHotelService : ISearchService
    {
        private readonly IHotelService _hotelService;
        private readonly IBookingRepository _bookingRepository;

        public LastMinuteHotelService(IHotelService hotelService, IBookingRepository bookingRepository)
        {
            _hotelService = hotelService;
            _bookingRepository = bookingRepository;
        }

        public async Task<SearchRes> SearchAsync(SearchReq request)
        {
            var options = new List<Option>();

           
                var hotels = await _hotelService.GetHotelsAsync(request.Destination);

                foreach (var hotel in hotels)
                {
                    var option = new Option()
                    {
                        HotelCode = hotel.HotelCode.ToString(),
                        FromDate = request.FromDate,
                        Price = 900.65, 
                    };

                    options.Add(option);
                    _bookingRepository.SaveOption(option);
                }

                return new SearchRes() { Options = options };
        }
    }
}
