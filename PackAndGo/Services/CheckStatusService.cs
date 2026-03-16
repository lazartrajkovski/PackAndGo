using PackAndGo.DTOs;
using PackAndGo.Repositories.Interfaces;
using PackAndGo.Services.Interfaces;

namespace PackAndGo.Services
{
    public class CheckStatusService : IStatusService
    {
        private readonly IBookingRepository _bookingRepository;

        public CheckStatusService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Task<CheckStatusRes> CheckStatusAsync(CheckStatusReq request)
        {
            var booking = _bookingRepository.GetBooking(request.BookingCode);

            if (booking == null)
            {
                throw new KeyNotFoundException("Booking not found!");
            }
            else
            {
                var completionTime = booking.BookingTime.AddSeconds(booking.SleepTime);

                if (DateTime.UtcNow < completionTime)
                {
                    return Task.FromResult(new CheckStatusRes { BookingStatus = Enums.BookingStatus.Pending });
                } 
                else if (booking.FromDate <= DateTime.UtcNow.AddDays(45))
                {
                    return Task.FromResult(new CheckStatusRes { BookingStatus = Enums.BookingStatus.Failed });
                }
                else
                {
                    return Task.FromResult(new CheckStatusRes { BookingStatus = Enums.BookingStatus.Success });
                }
            }
        }
    }
}
