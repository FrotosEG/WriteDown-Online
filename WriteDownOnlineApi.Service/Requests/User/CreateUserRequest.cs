using MediatR;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Requests.User
{
    public class CreateUserRequest : IRequest<BaseResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string Password { get; set; }

    }
}
