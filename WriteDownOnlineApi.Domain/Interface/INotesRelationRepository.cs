using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Interface.Core;

namespace WriteDownOnlineApi.Domain.Interface
{
    public interface INotesRelationRepository : IRepository<NotesRelationEntity, long>
    {
    }
}
