using System.ComponentModel.DataAnnotations;

namespace PracticeFor_B_Review.Models
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
