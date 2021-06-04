namespace RestApi.Domain.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        public User User { get; set; } 
        public string Name { get; set; }
        public bool IsConfirmed { get; set; }
        public string Description { get; set; }
        public int? LocationId { get; set; }
        public Location Location { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Website { get; set; }
        public string SocialMedia { get; set; }
        public string ListString { get; set; }
    }
}
