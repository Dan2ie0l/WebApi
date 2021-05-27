namespace RestApi.Domain.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Website { get; set; }
        public string SocialMedia { get; set; }
        public string ListString { get; set; }
    }
}
