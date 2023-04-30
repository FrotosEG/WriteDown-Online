using MediatR;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.User
{
    public class DeleteUserRequest : IRequest<IOperationResultBase>
    {
        public long UserId { get; set; }
    }
}
