using MediatR;
using WriteDownOnlineApi.Service.Responses.Note;

namespace WriteDownOnlineApi.Service.Requests.Note
{
    public class FindUserNotesRequest : IRequest<FindUserNotesResponse>
    {
        public long UserId { get; set; }
    }
}
