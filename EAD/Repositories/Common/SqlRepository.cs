using EAD.Interfaces;
using EAD.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EAD.Repositories.Common
{
    public class SqlRepository<T> : ISqlRepository<T> where T : class
    {
        private readonly OcrDbContext _dbContext = null;

        private readonly DbSet<T> _objectSet;

        public SqlRepository(OcrDbContext dbContext)
        {
            _dbContext = dbContext;
            _objectSet = dbContext.Set<T>();
        }

        public void Add(T obj)
        {
            if (obj != null)
            {
                _objectSet.Add(obj);
                _dbContext.Entry(obj).State = EntityState.Added;
            }
        }

        public void Delete(T obj)
        {
            if (obj != null)
            {
                _dbContext.Entry(obj).State = EntityState.Deleted;
            }
        }

        public async Task<List<T>> GetAll()
        {
            return await _objectSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _objectSet.FindAsync(id);
        }

        public async Task<T> GetById(string id)
        {
            return await _objectSet.FindAsync(id);
        }

        public void Update(T obj)
        {
            if (obj != null)
            {
                _dbContext.Entry(obj).State = EntityState.Modified;
            }
        }
    }
}