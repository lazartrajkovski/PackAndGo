namespace PackAndGo.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public int HotelCode { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public string DestinationCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

    }
}
