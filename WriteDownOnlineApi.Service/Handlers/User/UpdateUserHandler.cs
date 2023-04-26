using MediatR;
using WriteDownOnlineApi.Domain.Dtos;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.User;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Handlers.User
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, BaseResponse>
    {
        private readonly IUsersRepository _usersRepository;
        public UpdateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<BaseResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
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

                var password = PasswordHasher.Hash(request.Password);
                user.Password = password;
                user.Name = request.Name;
                user.Email = request.Email;
                user.Fone = request.Fone;

                _usersRepository.Update(user);
                _usersRepository.SaveChanges();

                response.StatusCode = 200;
                response.Sucesso = true;
                response.MensagemSucesso = "Usuário atualizado com sucesso";
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Sucesso = false;
                response.MensagemSucesso = $"Exception: {ex.Message}, Inner: {ex.InnerException?.Message}.";
            }

            return Task.FromResult(response);
        }
    }
}
