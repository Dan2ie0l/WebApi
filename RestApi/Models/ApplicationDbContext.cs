using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Tables> Tables { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }



        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
    }
}
