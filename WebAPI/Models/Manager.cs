namespace WebAPI.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Band> Bands { get; set; }
    }
}
