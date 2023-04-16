using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.User;
using WriteDownOnlineApi.Service.Responses.User;

namespace WriteDownOnlineApi.Service.Handlers.User
{
    public class FindUserHandler : IRequestHandler<FindUserRequest, FindUserResponse>
    {
        private readonly IUsersRepository _usersRepository;
        public FindUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<FindUserResponse> Handle(FindUserRequest request, CancellationToken cancellationToken)
        {
            var response = new FindUserResponse();
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

                response.StatusCode = 200;
                response.Sucesso = true;
                response.MensagemSucesso = "Usuário encontrado com sucesso";
                response.Name = user.Name;
                response.Email = user.Email;
                response.Fone = user.Fone;
                response.IdStatus = user.IdStatus;
                response.CreateDate = user.CreateDate;
                response.UpdateDate = user.UpdateDate;
                response.StatusUpdateDate = user.StatusUpdateDate;
                response.IdStatus = user.IdStatus;

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
