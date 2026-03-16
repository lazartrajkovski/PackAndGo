using PackAndGo.Models;
using PackAndGo.Repositories.Interfaces;

namespace PackAndGo.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly Dictionary<string, Option> _options = new Dictionary<string, Option>();
        private readonly Dictionary<string, Booking> _bookings = new Dictionary<string, Booking>();

        public Booking GetBooking(string bookingCode)
        {
            return _bookings[bookingCode];
        }

        public Option GetOption(string optionCode)
        {
            return _options[optionCode];
        }

        public void SaveBooking(Booking booking)
        {
            _bookings.Add(booking.BookingCode, booking);
        }

        public void SaveOption(Option option)
        {
           _options.Add(option.OptionCode, option);
        }
    }
}
