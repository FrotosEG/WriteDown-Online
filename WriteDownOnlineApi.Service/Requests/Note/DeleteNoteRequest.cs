using MediatR;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Requests.Note
{
    public class DeleteNoteRequest : IRequest<BaseResponse>
    {
        public long NoteId { get; set; }
    }
}
