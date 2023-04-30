using MediatR;
using WriteDownOnlineApi.Service.Responses.User;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.User
{
    public class LoginUserRequest : IRequest<IOperationResult<LoginUserResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
