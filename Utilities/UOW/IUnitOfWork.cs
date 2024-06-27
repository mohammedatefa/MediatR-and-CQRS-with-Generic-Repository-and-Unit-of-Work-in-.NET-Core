using CQRS_MediatR.Repository;

namespace CQRS_MediatR.Utilities.UOW
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task<int> SaveChanges();
    }
}
