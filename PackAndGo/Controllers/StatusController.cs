using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackAndGo.DTOs;
using PackAndGo.Services.Interfaces;

namespace PackAndGo.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatus([FromQuery] string bookingCode)
        {
            if (string.IsNullOrWhiteSpace(bookingCode))
            {
                return BadRequest("bookingCode is required.");
            }
                
            try
            {
                var result = await _statusService.CheckStatusAsync(new CheckStatusReq { BookingCode = bookingCode });
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
