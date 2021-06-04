using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestApi.Domain.Interfaces
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

        Task InsertAsync(T item);
        Task InsertRangeAsync(IEnumerable<T> items);

        void Update(T item);
        void Delete(T item);
    }
}
