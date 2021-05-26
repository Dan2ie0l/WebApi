using RestApi.Domain.Core;
using RestApi.Domain.Interfaces;
using RestApi.Domain.Interfaces;
using RestApi.Implementations.Data;
using RestApi.Infrastructure.Data;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        private IAsyncRepository<Restaurant> restaurantRepository;
        private IAsyncRepository<Reservation> reservationRepository;
        private IAsyncRepository<Table> tableRepository;

        public IAsyncRepository<Restaurant> Restaurants { get => restaurantRepository ??= new BaseRepository<Restaurant>(context); }
        public IAsyncRepository<Reservation> Reservations { get => reservationRepository ??= new BaseRepository<Reservation>(context); }
        public IAsyncRepository<Table> Tables { get => tableRepository ??= new BaseRepository<Table>(context); }

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
