using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class ManagerCreateUpdateDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
