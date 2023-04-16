using MediatR;
using WriteDownOnlineApi.Service.Responses.Core;
using WriteDownOnlineApi.Service.Responses.User;

namespace WriteDownOnlineApi.Service.Requests.User
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
