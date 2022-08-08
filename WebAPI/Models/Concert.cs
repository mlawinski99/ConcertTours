namespace WebAPI.Models
{
    public class Concert
    {
        public int ConcertId { get; set; }
        public string City { get; set; }
        public DateTime ConcertStartDateTime { get; set; }
        private int DurationInMinutes { get; set; }
        public ConcertTour ConcertTour { get; set; }
        public int ConcertTourId { get; set; }
    }
}
