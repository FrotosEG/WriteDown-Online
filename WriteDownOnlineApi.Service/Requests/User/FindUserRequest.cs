using MediatR;
using WriteDownOnlineApi.Service.Responses.User;

namespace WriteDownOnlineApi.Service.Requests.User
{
    public class FindUserRequest : IRequest<FindUserResponse>
    {
        public long UserId { get; set; }
    }
}
