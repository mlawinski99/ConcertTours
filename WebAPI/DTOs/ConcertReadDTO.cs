using WebAPI.Models;

namespace WebAPI.DTOs
{
    public class ConcertReadDTO
    {
        public int ConcertId { get; set; }
        public string City { get; set; }
        public DateTime ConcertStartDateTime { get; set; }
        private int DurationInMinutes { get; set; }
       // public ConcertTourReadDTO ConcertTour { get; set; }
    }
}
