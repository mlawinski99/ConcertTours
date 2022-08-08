namespace WebAPI.Models
{
    public class Band
    {
        public int BandId { get; set; }
        public string Name { get; set; }
        public  ICollection<ConcertTour>? ConcertTours { get; set; }
        public  Manager Manager { get; set; }
        public int ManagerId { get; set; }

    }
}
