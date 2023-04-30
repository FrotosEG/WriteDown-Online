using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.User;
using WriteDownOnlineApi.Service.Responses.User;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.User
{
    public class FindUserHandler : IRequestHandler<FindUserRequest, IOperationResult<FindUserResponse>>
    {
        private readonly IUsersRepository _usersRepository;
        public FindUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<IOperationResult<FindUserResponse>> Handle(FindUserRequest request, CancellationToken cancellationToken)
        {
            var response = new FindUserResponse();
            try
            {
                var user = _usersRepository.GetById(request.UserId);
                if (user == null)
                    return Task.FromResult(OperationResult<FindUserResponse>.CreateNotFound().AddMessage("Nota não encontrada."));

                response.Name = user.Name;
                response.Email = user.Email;
                response.Fone = user.Fone;
                response.IdStatus = user.IdStatus;
                response.CreateDate = user.CreateDate;
                response.UpdateDate = user.UpdateDate;
                response.StatusUpdateDate = user.StatusUpdateDate;
                response.IdStatus = user.IdStatus;

                return Task.FromResult(OperationResult<FindUserResponse>.CreateSuccess(response));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResult<FindUserResponse>.CreateInternalError(ex).AddMessage("Ocorreu um erro ao buscar o usuário."));

            }
        }
    }
}
