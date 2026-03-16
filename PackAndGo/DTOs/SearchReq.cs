using System.ComponentModel.DataAnnotations;

namespace PackAndGo.DTOs
{
    public class SearchReq
    {
        [Required]
        public string Destination { get; set; } = string.Empty;
        public string ?DepartureAirport { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
    }
}
