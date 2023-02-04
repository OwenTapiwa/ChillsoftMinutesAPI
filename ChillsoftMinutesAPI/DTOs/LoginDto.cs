using System.ComponentModel.DataAnnotations;

namespace ChillsoftMinutesAPI.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "The Username field is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password field is required.")]
        public string Password { get; set; }
    }
}
