using System.ComponentModel.DataAnnotations;

namespace ChillsoftMinutesAPI.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "The First Name field is required.")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = "The Username field is required.")]
        //public string Username { get; set; }
        [Required(ErrorMessage = "The Last Name field is required.")]
        public string LastName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Password field is required.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
         ErrorMessage = "Password must meet requirements.Password should have minimum eight characters, at least one letter, one number and one special character")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Confirm Password field is required.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "The Phone Number field is required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "The Email Address field is required.")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        
    }
}
