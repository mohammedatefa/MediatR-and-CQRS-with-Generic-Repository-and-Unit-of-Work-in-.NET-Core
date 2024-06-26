using CQRS_MediatR.Context;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatR.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal NewsPaperContext _context;
        internal DbSet<T> _dbset;
        public GenericRepository(NewsPaperContext context)
        {
            this._context = context;
            this._dbset = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public  async Task<T> GetByIdAsync(int Id)
        {
            return await _dbset.FindAsync(Id);
        }
        public async Task AddAsync(T entity)
        {
            await _dbset.AddAsync(entity);
        }

        public async Task DeleteAsync(object Id)
        {
            var entity = await _dbset.FindAsync(Id);
            if (entity != null)
                _dbset.Remove(entity);
        } 

        public async Task UpdateAsync(object Id, T entity)
        {
            var entityToUpdate = await _dbset.FindAsync(Id);
            if (entityToUpdate != null)
                _dbset.Update(entity);
        }
    }
}
