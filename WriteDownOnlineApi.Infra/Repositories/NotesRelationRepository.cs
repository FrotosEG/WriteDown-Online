using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Domain.Interface.Core;
using WriteDownOnlineApi.Infra.Repositories.Core;

namespace WriteDownOnlineApi.Infra.Repositories
{
    public class NotesRelationRepository : Repository<NotesRelationEntity, long>, INotesRelationRepository
    {
        private readonly IUnitOfWork<DbContext> _unitOfWork;
        public NotesRelationRepository(DbContext context, IUnitOfWork<DbContext> unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public List<NotesRelationEntity> GetNotesRelationByIdNote(long noteId)
        {
            return _dbSet.Where(d => d.NoteId == noteId).ToList();
        }
    }
}
