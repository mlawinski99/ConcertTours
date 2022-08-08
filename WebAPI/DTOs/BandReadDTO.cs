using WebAPI.Models;

namespace WebAPI.DTOs
{
    public class BandReadDTO
    {
        public int BandId { get; set; }
        public string Name { get; set; }
        public ICollection<ConcertTour> ConcertTours { get; set; }
    }
}
