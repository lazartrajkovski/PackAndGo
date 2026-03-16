using PackAndGo.DTOs;

namespace PackAndGo.Services.Interfaces
{
    public interface ISearchService
    {
        Task<SearchRes> SearchAsync(SearchReq request);
    }
}
