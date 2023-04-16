using MediatR;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Requests.User
{
    public class DeleteUserRequest : IRequest<BaseResponse>
    {
        public long UserId { get; set; }
    }
}
