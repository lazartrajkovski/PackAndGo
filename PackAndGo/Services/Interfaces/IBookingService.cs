using PackAndGo.DTOs;

namespace PackAndGo.Services.Interfaces
{
    public interface IBookingService
    {
        Task <BookRes> BookAsync(BookReq request);
    }
}
