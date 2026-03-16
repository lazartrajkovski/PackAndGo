using Microsoft.AspNetCore.Mvc;
using PackAndGo.DTOs;
using PackAndGo.Services.Interfaces;

namespace PackAndGo.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchTypeService _searchTypeService;

        public SearchController(ISearchTypeService searchTypeService)
        {
            _searchTypeService = searchTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] SearchReq request)
        {
            try
            {
                var result = await _searchTypeService.SearchTypeAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message }); 
            }
        }
    }
}
