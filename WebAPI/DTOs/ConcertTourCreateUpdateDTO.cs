using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class ConcertTourCreateUpdateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
