using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class ConcertCreateUpdateDTO
    {
        [Required]
        public DateTime ConcertStartDateTime { get; set; }
        [Required]
        public int DurationInMinutes { get; set; }
        [Required]
        public string City { get; set; }
    }
}
