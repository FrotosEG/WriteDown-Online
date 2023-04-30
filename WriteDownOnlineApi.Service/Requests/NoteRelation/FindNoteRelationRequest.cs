using MediatR;
using WriteDownOnlineApi.Service.Responses.NoteRelation;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.NoteRelation
{
    public class FindNoteRelationRequest : IRequest<IOperationResult<List<FindNoteRelationResponse>>>
    {
        public long NoteId { get; set; }
    }
}
