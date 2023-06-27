using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T? GetById(int id);
        void Update(T entity);
        List<T> GetAll();
        Task<List<T>> GetAllAsync();
    }
}
