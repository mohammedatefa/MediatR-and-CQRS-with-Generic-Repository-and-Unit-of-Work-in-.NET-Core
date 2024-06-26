using CQRS_MediatR.Repository;

namespace CQRS_MediatR.Utilities
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<int> SaveChanges();
    }
}
