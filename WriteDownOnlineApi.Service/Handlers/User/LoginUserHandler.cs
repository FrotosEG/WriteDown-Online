using MediatR;
using WriteDownOnlineApi.Domain.Dtos;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.User;
using WriteDownOnlineApi.Service.Responses.User;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.Usuario
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, IOperationResult<LoginUserResponse>>
    {
        private readonly IUsersRepository _usersRepository;
        public LoginUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<IOperationResult<LoginUserResponse>> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var response = new LoginUserResponse();
            try
            {

                if (String.IsNullOrEmpty(request.Password))
                    return Task.FromResult(OperationResult<LoginUserResponse>.CreateInvalidInput().AddMessage("Senha não pode estar vazia."));

                if (String.IsNullOrEmpty(request.Email))
                    return Task.FromResult(OperationResult<LoginUserResponse>.CreateInvalidInput().AddMessage("Email não pode estar vazia."));

                var login = _usersRepository.FindUserByEmail(request.Email);
                if (login == null)
                    return Task.FromResult(OperationResult<LoginUserResponse>.CreateNotFound().AddMessage("Email ou senha incorretos. Tente novamente."));

                var authorize = PasswordHasher.Verify(request.Password, login.Password);
                if (!authorize)
                    return Task.FromResult(OperationResult<LoginUserResponse>.CreateInvalidInput().AddMessage("Email ou senha incorretos. Tente novamente."));

                response.Email = login.Email;
                response.Name = login.Name;
                response.Fone = login.Fone;
                response.UserId = login.Id;

                return Task.FromResult(OperationResult<LoginUserResponse>.CreateSuccess(response));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResult<LoginUserResponse>.CreateInternalError(ex).AddMessage("Ocorreu um erro ao realizar o login. Tente novamente mais tarde."));

            }
        }
    }
}
