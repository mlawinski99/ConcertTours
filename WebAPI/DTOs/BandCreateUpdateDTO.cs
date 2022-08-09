using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class BandCreateUpdateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
