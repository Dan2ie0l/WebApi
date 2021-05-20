using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }


    }
}
