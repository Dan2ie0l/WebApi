using RestApi.Domain.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace RestApi.Infrastructure.Data
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly DbSet<T> Entities;
        private readonly DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            Entities = context.Set<T>();
        }
        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> entities = Entities;
            entities = include(entities);

            return await entities.FirstOrDefaultAsync(filter);
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }

        public async virtual Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = Entities;

            if (!(filter is null))
            {
                query = query.Where(filter);
            }

            if (!(include is null))
            {
                query = include(query);
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

        public virtual async Task InsertAsync(T item) => await Entities.AddAsync(item);
        public virtual async Task InsertRangeAsync(IEnumerable<T> items) => await Entities.AddRangeAsync(items);

        public virtual void Delete(T item) => Entities.Remove(item);

        public virtual void Update(T item)
        {
            Entities.Attach(item);
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
