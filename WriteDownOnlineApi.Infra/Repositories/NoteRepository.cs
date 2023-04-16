using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Domain.Interface.Core;
using WriteDownOnlineApi.Infra.Repositories.Core;

namespace WriteDownOnlineApi.Infra.Repositories
{
    public class NoteRepository : Repository<NoteEntity, long>, INoteRepository
    {
        private readonly IUnitOfWork<DbContext> _unitOfWork;
        public NoteRepository(DbContext context, IUnitOfWork<DbContext> unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public List<NoteEntity> FindUserNotes(long userId)
        {
            return _dbSet.Where(d => d.UsersCreated.Id == userId).ToList();
        }
    }
}
