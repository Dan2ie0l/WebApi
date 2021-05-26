using RestApi.Domain.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestApi.Infrastructure.Data
{
    public class BaseReposirory<T> : IAsyncRepository<T> where T : class
    {
        protected readonly DbSet<T> Entities;
        private readonly DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            Entities = context.Set<T>();
        }
        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await Entities.FirstOrDefaultAsync(filter);
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = Entities;

            if (!(filter is null))
            {
                query = query.Where(filter);
            }

            if (!(includeProperties is null))
            {
                foreach (var includeProperty in includeProperties.Split
                    (',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (!(orderBy is null))
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
    }
}
