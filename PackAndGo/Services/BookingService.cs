using PackAndGo.DTOs;
using PackAndGo.Exceptions;
using PackAndGo.Models;
using PackAndGo.Repositories.Interfaces;
using PackAndGo.Services.Interfaces;

namespace PackAndGo.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<BookRes> BookAsync(BookReq request)
        {
            var option = _bookingRepository.GetOption(request.OptionCode);

            if (option == null)
                throw new AppException("Option not found!");

            var newBooking = new Booking()
            {
                BookingTime = DateTime.UtcNow,
                FromDate = option.FromDate
            };

            _bookingRepository.SaveBooking(newBooking);

            return new BookRes
            {
                BookingCode = newBooking.BookingCode,
                BookingTime = newBooking.BookingTime
            };
        }
    }
}
