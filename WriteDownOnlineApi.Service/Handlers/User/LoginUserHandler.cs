using MediatR;
using WriteDownOnlineApi.Domain.Dtos;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.User;
using WriteDownOnlineApi.Service.Responses.User;

namespace WriteDownOnlineApi.Service.Handlers.Usuario
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IUsersRepository _usersRepository;
        public LoginUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var response = new LoginUserResponse();
            try
            {
                response.StatusCode = 400;
                response.Sucesso = false;

                if (String.IsNullOrEmpty(request.Password))
                {
                    response.MensagemSucesso = "Por favor informe uma senha.";
                    return Task.FromResult(response);
                }

                if (String.IsNullOrEmpty(request.Email))
                {
                    response.MensagemSucesso = "Por favor informe uma email.";
                    return Task.FromResult(response);
                }

                var login = _usersRepository.FindUserByEmail(request.Email);
                if (login == null)
                {
                    response.StatusCode = 404;
                    response.MensagemSucesso = "Email ou senha incorretos.";
                    return Task.FromResult(response);
                }

                var authorize = PasswordHasher.Verify(request.Password, login.Password);
                if (!authorize)
                {
                    response.StatusCode = 404;
                    response.MensagemSucesso = "Email ou senha incorretos.";
                    return Task.FromResult(response);
                }

                response.Email = login.Email;
                response.Name = login.Name;
                response.Fone = login.Fone;
                response.UserId = login.Id;
                response.StatusCode = 200;
                response.Sucesso = true;
                response.MensagemSucesso = "Usuário logado com sucesso.";

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
