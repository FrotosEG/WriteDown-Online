using MediatR;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Requests.User
{
    public class UpdateUserRequest : IRequest<BaseResponse>
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string Password { get; set; }
    }
}
