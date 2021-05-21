using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class EFRepo : Repository
    {
        private readonly ApplicationDbContext context;
        public EFRepo(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Tables> Tables => context.Tables;
        public IEnumerable<Reservation> Reservations => context.Reservation;
        public IEnumerable<Restaurant> Restaurants => context.Restaurant;
        public IEnumerable<User> Users => context.Users;
    }
}
