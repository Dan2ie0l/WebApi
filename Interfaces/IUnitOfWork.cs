using RestApi.Domain.Core;
using System.Threading.Tasks;

namespace RestApi.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAsyncRepository<Restaurant> Restaurants { get; }
        IAsyncRepository<Table> Tables { get;  }
        IAsyncRepository<Reservation> Reservations { get; }

        void Commit();
        Task CommitAsync();
    }
}
