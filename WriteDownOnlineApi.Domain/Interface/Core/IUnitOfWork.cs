namespace WriteDownOnlineApi.Domain.Interface.Core
{
    public interface IUnitOfWork<TContext>
    {
        Task CommitAsync();
    }
}
