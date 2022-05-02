namespace Catalog.API.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
