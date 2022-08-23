namespace WebAPI.DTOs
{
    public class ConcertReadDTO
    {
        public int ConcertId { get; set; }
        public DateTime ConcertStartDateTime { get; set; }
        public int DurationInMinutes { get; set; }
        public string City { get; set; }
        // public ConcertTourReadDTO ConcertTour { get; set; }
    }
}
