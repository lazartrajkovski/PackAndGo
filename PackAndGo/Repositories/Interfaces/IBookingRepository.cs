using PackAndGo.DTOs;
using PackAndGo.Models;

namespace PackAndGo.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        void SaveOption(Option option);
        Option GetOption(string optionCode);
        void SaveBooking(Booking booking);
        Booking GetBooking(string bookingCode);

    }
}
