using PackAndGo.Models;

namespace PackAndGo.ExternalApiServices.Interfaces
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetHotelsAsync(string destinationCode);
    }
}
