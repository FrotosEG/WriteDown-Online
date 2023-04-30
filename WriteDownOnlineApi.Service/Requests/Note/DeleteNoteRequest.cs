using MediatR;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.Note
{
    public class DeleteNoteRequest : IRequest<IOperationResultBase>
    {
        public long NoteId { get; set; }
    }
}
