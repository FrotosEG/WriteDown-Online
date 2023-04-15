using WriteDownOnlineApi.Domain.Interface.Core;

namespace WriteDownOnlineApi.Infra.Repositories.Core
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
            => await _context.SaveChangesAsync();
    }
}
