using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.User;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Handlers.User
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, BaseResponse>
    {
        private readonly IUsersRepository _usersRepository;
        public DeleteUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<BaseResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                var user = _usersRepository.GetById(request.UserId);
                if (user == null)
                {
                    response.StatusCode = 404;
                    response.Sucesso = false;
                    response.MensagemSucesso = $"Usuário não encontrado.";
                    return Task.FromResult(response);
                }

                _usersRepository.Delete(request.UserId);
                _usersRepository.SaveChanges();

                response.StatusCode = 200;
                response.Sucesso = true;
                response.MensagemSucesso = "Usuário deletado com sucesso.";

                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Sucesso = false;
                response.MensagemSucesso = $"Exception: {ex.Message}, Inner: {ex.InnerException?.Message}.";
                return Task.FromResult(response);
            }
        }
    }
}
