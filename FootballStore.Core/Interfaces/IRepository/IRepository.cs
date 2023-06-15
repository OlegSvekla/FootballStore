using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.Interfaces.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();     
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}