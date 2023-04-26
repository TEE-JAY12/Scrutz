namespace Scrutz.Repository.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        Task CompleteAsync();
    }
}
