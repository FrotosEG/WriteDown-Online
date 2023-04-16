using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Interface.Core;

namespace WriteDownOnlineApi.Domain.Interface
{
    public interface INoteRepository : IRepository<NoteEntity, long>
    {
        List<NoteEntity> FindUserNotes(long userId);
    }
}
