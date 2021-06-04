namespace RestApi.Domain.Core
{
    public class Location
    {
        public int Id { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Address { get; set; }

        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}
