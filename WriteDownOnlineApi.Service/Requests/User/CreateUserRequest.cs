using MediatR;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.User
{
    public class CreateUserRequest : IRequest<IOperationResultBase>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string Password { get; set; }

    }
}
