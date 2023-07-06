using FootballStore.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly CatalogContext _dBContext;

        public EfRepository(CatalogContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            var result = await _dBContext.AddAsync<T>(entity);
            _ = await _dBContext.SaveChangesAsync();
            return entity;
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dBContext.Set<T>().ToListAsync();
        }

        public T? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
