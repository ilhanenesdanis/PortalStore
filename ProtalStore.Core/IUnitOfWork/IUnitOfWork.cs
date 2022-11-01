namespace PortalStore.Core.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        int saveChanges();
    }
}
