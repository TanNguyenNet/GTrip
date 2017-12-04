using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Services.Data
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<T> GetByIdAsync(object id);

        Task<T> InsertAsync(T entity);

        Task<int> InsertAsync(IEnumerable<T> entities);

        Task<T> UpdateAsync(T entity);

        Task<int> UpdateAsync(IEnumerable<T> entities);

        Task DeleteAsync(T entity);

        Task<int> DeleteAsync(IEnumerable<T> entities);

        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
    }
}
