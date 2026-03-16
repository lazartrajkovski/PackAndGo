using PackAndGo.DTOs;

namespace PackAndGo.Services.Interfaces
{
    public interface IStatusService
    {
        Task<CheckStatusRes> CheckStatusAsync(CheckStatusReq request);
    }
}
