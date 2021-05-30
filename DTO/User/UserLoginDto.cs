using System.ComponentModel.DataAnnotations;

namespace RestApi.Services.DTO.User
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Enter the login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter the password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
