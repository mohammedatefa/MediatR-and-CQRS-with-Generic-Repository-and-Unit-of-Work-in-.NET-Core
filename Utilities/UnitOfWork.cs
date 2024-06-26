using CQRS_MediatR.Context;
using CQRS_MediatR.Repository;
using System.Collections;

namespace CQRS_MediatR.Utilities
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NewsPaperContext _newsPaperContext;
        private Hashtable Repositories;
        public UnitOfWork(NewsPaperContext newsPaperContext)
        {
            _newsPaperContext = newsPaperContext;
            Repositories = new Hashtable();
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T).Name;
            if (!Repositories.ContainsKey(type))
            {
                var repo =new GenericRepository<T>(_newsPaperContext);
                Repositories.Add(type,repo);
            }
            return Repositories[type] as IGenericRepository<T>;
        }

        public async Task<int> SaveChanges()
             => await _newsPaperContext.SaveChangesAsync();
        public async ValueTask DisposeAsync()
             => await _newsPaperContext.DisposeAsync();
    }
}
