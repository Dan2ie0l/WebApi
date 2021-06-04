using RestApi.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IReservationService
    {
        /// <summary>
        /// Gets Reservation record from Database by ID
        /// </summary>
        /// <param name="id">Unique identifier for Reservation</param>
        /// <returns>Reservation instance, if it exists, else null</returns>
        Task<Reservation> GetByIdAsync(int id);

        /// <summary>
        /// Gets all Reservations by condition
        /// </summary>
        /// <param name="expression">Condition (lambda)</param>
        /// <returns>Collection of Reservation instances, if at least 1 Reservation meets the conditions, else null</returns>
        Task<IEnumerable<Reservation>> GetAllAsync(Expression<Func<Reservation, bool>> expression = null);

        /// <summary>
        /// Create a new Reservation record in Database
        /// </summary>
        /// <param name="Reservation">Reservation data instance</param>
        /// <returns></returns>
        Task CreateAsync(Reservation Reservation);

        /// <summary>
        /// Delete Reservation record from Database
        /// </summary>
        /// <param name="Reservation">Reservation data instance</param>
        /// <returns></returns>
        Task DeleteAsync(Reservation Reservation);

        /// <summary>
        /// Update an already existing Reservation record
        /// </summary>
        /// <param name="Reservation">Reservation new instance</param>
        /// <returns></returns>
        Task UpdateAsync(Reservation Reservation);
    }
}
