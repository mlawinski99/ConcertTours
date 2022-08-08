using WebAPI.Models;

namespace WebAPI.DTOs
{
    public class ConcertTourReadDTO
    {
        public int ConcertTourId { get; set; }
        public string Name { get; set; }
        public Band Band { get; set; }
        public ICollection<Concert> Concerts { get; set; }
        
    }
}
