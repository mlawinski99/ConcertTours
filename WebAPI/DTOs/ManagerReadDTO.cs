namespace WebAPI.DTOs
{
    public class ManagerReadDTO
    {
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<BandReadDTO> Bands { get; set; }
    }
}
