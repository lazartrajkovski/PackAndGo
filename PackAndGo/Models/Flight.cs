namespace PackAndGo.Models
{
    public class Flight
    {
        public int FlightCode { get; set; }
        public string FlightNumber { get; set; } = string.Empty;
        public string DepartureAirport { get; set; } = string.Empty;
        public string ArrivalAirport { get; set; } = string.Empty;
    }
}
