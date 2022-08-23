
namespace WebAPI.DTOs
{
    public class BandReadDTO
    {
        public int BandId { get; set; }
        public string Name { get; set; }
        public ICollection<ConcertTourReadDTO> ConcertTours { get; set; }
    }
}
