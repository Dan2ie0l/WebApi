using System.ComponentModel.DataAnnotations;

namespace RestApi.Services.DTO
{
    public class RestaurantDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the name of restaurant"), MaxLength(25, ErrorMessage = "Max length is 25")]
        public string Name { get; set; }

        [MaxLength(120, ErrorMessage = "Max length is 120")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Select the location")]
        public LocationDto Location { get; set; }

        [Phone(ErrorMessage = "Enter a valid phone number"), Required(ErrorMessage = "Enter the phone for contact")]
        public string Phone1 { get; set; }

        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string Phone2 { get; set; }

        [Url(ErrorMessage = "Enter a valid URL")]
        public string Website { get; set; }

        [Url(ErrorMessage = "Enter a valid URL")]
        public string SocialMedia { get; set; }
    }
}
