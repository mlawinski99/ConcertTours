namespace WebAPI.DTOs
{
    public class ConcertCreateUpdateDTO
    {
       
        public DateTime ConcertStartDateTime { get; set; }
        private int DurationInMinutes { get; set; }
        public string City { get; set; }
    }
}
