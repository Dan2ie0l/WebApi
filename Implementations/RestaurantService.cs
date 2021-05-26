using RestApi.Domain.Core;
using RestApi.Domain.Interfaces;
using RestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestApi.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private IUnitOfWork
        public async Task CreateAsync(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync(Expression<Func<Restaurant, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
