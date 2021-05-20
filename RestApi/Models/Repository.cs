using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public interface Repository
    {
        IEnumerable<Restaurant> Restaurants { get; }
        IEnumerable<Reservation> Reservations { get; }
        IEnumerable<Tables> Tables { get; }
        IEnumerable<User> Users { get; }

    }
}
