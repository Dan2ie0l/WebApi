using RestApi.Domain.Core;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RestApi.Services.Interfaces
{
    public interface IRestaurantService
    {
        /// <summary>
        /// Gets restaurant record from Database by ID
        /// </summary>
        /// <param name="id">Unique identifier for restaurant</param>
        /// <returns>Restaurant instance, if it exists, else null</returns>
        Task<Restaurant> GetByIdAsync(int id);

        /// <summary>
        /// Gets all restaurants by condition
        /// </summary>
        /// <param name="expression">Condition (lambda)</param>
        /// <returns>Collection of restaurant instances, if at least 1 restaurant meets the conditions, else null</returns>
        Task<IEnumerable<Restaurant>> GetAllAsync(Expression<Func<Restaurant, bool>> expression = null);

        /// <summary>
        /// Create a new restaurant record in Database
        /// </summary>
        /// <param name="restaurant">Restaurant data instance</param>
        /// <returns></returns>
        Task CreateAsync(Restaurant restaurant);

        /// <summary>
        /// Delete restaurant record from Database
        /// </summary>
        /// <param name="restaurant">Restaurant data instance</param>
        /// <returns></returns>
        Task DeleteAsync(Restaurant restaurant);

        /// <summary>
        /// Update an already existing restaurant record
        /// </summary>
        /// <param name="restaurant">Restaurant new instance</param>
        /// <returns></returns>
        Task UpdateAsync(Restaurant restaurant);
    }
}
