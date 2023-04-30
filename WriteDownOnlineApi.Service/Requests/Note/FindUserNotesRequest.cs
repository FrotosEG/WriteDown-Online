using MediatR;
using WriteDownOnlineApi.Service.Responses.Note;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.Note
{
    public class FindUserNotesRequest : IRequest<IOperationResult<FindUserNotesResponse>>
    {
        public long UserId { get; set; }
    }
}
