using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace Models
{
    public class Band
    {
        public int BandId { get; set; }
        public string Name { get; set; }
        public ICollection<ConcertTour>? ConcertTours { get; set; } = new Collection<ConcertTour>();
        public Manager Manager { get; set; }
        public int ManagerId { get; set; }

    }
}
