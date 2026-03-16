using PackAndGo.Enums;

namespace PackAndGo.Models
{
    public class Booking
    {
        private const string _chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string GenerateBookingCode()
        {
            return new string(Enumerable.Range(0, 6)
                .Select(_ => _chars[Random.Shared.Next(_chars.Length)])
                .ToArray());
        }
        public string BookingCode { get; set; } = GenerateBookingCode();
        public int SleepTime { get; set; } = Random.Shared.Next(30, 61);
        public DateTime BookingTime { get; set; } = DateTime.UtcNow;
        public DateTime FromDate { get; set; }
    }
}
