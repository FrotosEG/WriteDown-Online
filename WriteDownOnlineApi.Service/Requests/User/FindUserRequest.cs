using MediatR;
using WriteDownOnlineApi.Service.Responses.User;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.User
{
    public class FindUserRequest : IRequest<IOperationResult<FindUserResponse>>
    {
        public long UserId { get; set; }
    }
}
