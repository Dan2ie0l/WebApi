using RestApi.Domain.Core;
using RestApi.Domain.Interfaces;
using RestApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            return await unitOfWork.Restaurants.GetAllAsync(expression, include: c => c.Include(t => t.User)
                                                                                .Include(t => t.Location));
        }

        public async Task<Restaurant> GetByIdAsync(int id)
        {
            return await unitOfWork.Restaurants.GetAsync(t => t.Id == id, c => c.Include(t => t.User)
                                                                                .Include(t => t.Location));
        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            if (!(restaurant is null))
            {
                unitOfWork.Restaurants.Update(restaurant);
                await unitOfWork.CommitAsync();
            }
        }
    }
}
