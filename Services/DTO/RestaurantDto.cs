using System.ComponentModel.DataAnnotations;

namespace RestApi.Services.DTO
{
    public class RestaurantDto
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(120)]
        public string Description { get; set; }

        [Required]
        public LocationDto Location { get; set; }

        [Phone, Required]
        public string Phone1 { get; set; }

        [Phone]
        public string Phone2 { get; set; }

        [Url]
        public string Website { get; set; }

        [Url]
        public string SocialMedia { get; set; }
    }
}
