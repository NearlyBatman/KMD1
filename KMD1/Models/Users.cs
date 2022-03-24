using System.ComponentModel.DataAnnotations;

namespace KMD1.Models
{
    public class Users
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
