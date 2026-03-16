using Microsoft.AspNetCore.Mvc;
using PackAndGo.DTOs;
using PackAndGo.Services.Interfaces;

namespace PackAndGo.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> Book([FromBody] BookReq request)
        {
            var result = await _bookingService.BookAsync(request);
            return Ok(result);
        }
    }
}
