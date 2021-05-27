using System;

namespace RestApi.Domain.Core
{
    public class Reservation
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int RestaurantId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
    }
}
