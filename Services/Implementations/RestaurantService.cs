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
        private readonly IUnitOfWork unitOfWork;

        public RestaurantService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(Restaurant restaurant)
        {
            await unitOfWork.Restaurants.InsertAsync(restaurant);
            await unitOfWork.CommitAsync();

        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            unitOfWork.Restaurants.Delete(restaurant);
            await unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllAsync(Expression<Func<Restaurant, bool>> expression = null)
        {
            return await unitOfWork.Restaurants.GetAllAsync(expression);
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await unitOfWork.Restaurants.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            if (!(restaurant is null))
            {
                unitOfWork.Restaurants.Update(restaurant);
                await unitOfWork.CommitAsync();
            }
        }

        public Task UpdateAsync(int id, Restaurant restaurant)
        {
            throw new NotImplementedException();
        }
    }
}
