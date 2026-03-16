using System.ComponentModel.DataAnnotations;

namespace PackAndGo.DTOs
{
    public class CheckStatusReq
    {
        [Required]
        public string BookingCode { get; set; } = string.Empty;
    }
}
