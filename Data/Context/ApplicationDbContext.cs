//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestApi.Domain.Core;

namespace RestApi.Implementations.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }

        public ApplicationDbContext() 
            : base("DefaultConnection")
        {

        }
    }
}
