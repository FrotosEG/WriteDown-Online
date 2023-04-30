using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.User;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, IOperationResultBase>
    {
        private readonly IUsersRepository _usersRepository;
        public DeleteUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<IOperationResultBase> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _usersRepository.GetById(request.UserId);
                if (user == null)
                    return Task.FromResult(OperationResultBase.CreateNotFound().AddMessage("Usuário não encontrado."));

                _usersRepository.Delete(request.UserId);
                _usersRepository.SaveChanges();
                return Task.FromResult(OperationResultBase.CreateSuccess());
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex).AddMessage("Ocorreu um erro ao buscar o usuário."));

            }
        }
    }
}
