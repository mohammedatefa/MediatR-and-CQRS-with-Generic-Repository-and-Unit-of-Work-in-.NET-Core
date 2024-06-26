namespace CQRS_MediatR.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetByIdAsync(int Id);
        public Task AddAsync(TEntity entity);
        public Task UpdateAsync(object Id,TEntity entity);
        public Task DeleteAsync(object Id);
    }
}
