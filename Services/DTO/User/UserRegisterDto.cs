using System.ComponentModel.DataAnnotations;

namespace RestApi.Services.DTO.User
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Enter your name!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your surname!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Enter your email"), EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter password!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password!"), Compare(nameof(Password), ErrorMessage = "Passwords doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
