using PackAndGo.DTOs;

namespace PackAndGo.Services.Interfaces
{
    public interface ISearchTypeService
    {
         Task<SearchRes> SearchTypeAsync(SearchReq request);
    }
}
