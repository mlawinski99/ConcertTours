using System.Collections.ObjectModel;

namespace Models
{
    public class ConcertTour
    {
        public int ConcertTourId { get; set; }
        public string Name { get; set; }

        public ICollection<Concert>? Concerts { get; set; } = new Collection<Concert>();
        public Band? Band { get; set; }
        public int BandId { get; set; }
    }
}
