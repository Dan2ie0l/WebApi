using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class Tables
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string State { get; set; }
        public int Quantity { get; set; }
    }
}
