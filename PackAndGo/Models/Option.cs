using PackAndGo.Enums;

namespace PackAndGo.Models
{
    public class Option
    {
        public string OptionCode { get; set; } = Guid.NewGuid().ToString();
        public string HotelCode { get; set; } = string.Empty;
        public string FlightCode { get; set; } = string.Empty;
        public string ArrivalAirport { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime FromDate { get; set; }
    }
}
