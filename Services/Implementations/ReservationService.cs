using RestApi.Domain.Core;
using RestApi.Domain.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork unitOfWork;

        public ReservationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Reservation reservation)
        {
            await unitOfWork.Reservations.InsertAsync(reservation);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Reservation reservation)
        {
            unitOfWork.Reservations.Delete(reservation);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllAsync(Expression<Func<Reservation, bool>> expression = null)
        {
            return await unitOfWork.Reservations.GetAllAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await unitOfWork.Reservations.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Reservation reservation)
        {
            if (!(reservation is null))
            {
                unitOfWork.Reservations.Update(reservation);
                await unitOfWork.CommitAsync();
            }
        }
    }
}
