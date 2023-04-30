using MediatR;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.NoteRelation
{
    public class UpdateNoteRelationRequest : IRequest<IOperationResultBase>
    {
        public long NoteRelationId { get; set; }
        public long IdNoteFrom { get; set; }
        public long IdNoteTo { get; set; }
        public short IdStatus { get; set; }
    }
}
