using MediatR;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.NoteRelation
{
    public class DeleteNoteRelationRequest : IRequest<IOperationResultBase>
    {
        public long NoteRelationId { get; set; }
    }
}
