namespace RestApi.Domain.Core
{
    public class Table
    {
        public int Id { get; set; }

        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public string State { get; set; }
        public int Quantity { get; set; }
    }
}
