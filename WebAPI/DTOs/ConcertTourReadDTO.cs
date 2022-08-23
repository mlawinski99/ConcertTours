namespace WebAPI.DTOs
{
    public class ConcertTourReadDTO
    {
        public int ConcertTourId { get; set; }
        public string Name { get; set; }
       // public BandReadDTO Band { get; set; }
        public ICollection<ConcertReadDTO> Concerts { get; set; }
        
    }
}
