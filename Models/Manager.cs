using System.Collections.ObjectModel;

namespace Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Band>? Bands { get; set; } = new Collection<Band>();
    }
}
