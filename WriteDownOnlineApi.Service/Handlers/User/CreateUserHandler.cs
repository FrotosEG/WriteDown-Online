using MediatR;
using WriteDownOnlineApi.Domain.Dtos;
using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Enums;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.User;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Handlers.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, BaseResponse>
    {
        private readonly IUsersRepository _usersRepository;
        public CreateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<BaseResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                response.StatusCode = 400;
                response.Sucesso = false;

                string password = "";
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

                if (String.IsNullOrEmpty(request.Fone))
                {
                    response.MensagemSucesso = "Por favor informe um telefone válido.";
                    return Task.FromResult(response);
                }

                if (String.IsNullOrEmpty(request.Name))
                {
                    response.MensagemSucesso = "Por favor informe nome.";
                    return Task.FromResult(response);
                }
                //verify if email already exists in DB
                var existingEmail = _usersRepository.FindUserByEmail(request.Email);
                if (existingEmail != null)
                {
                    response.MensagemSucesso = "Email já cadastrado.";
                    return Task.FromResult(response);
                }

                password = PasswordHasher.Hash(request.Password);
                var user = new UsersEntity()
                {
                    IdStatus = (short)EnumStatus.Created,
                    Email = request.Email,
                    Fone = request.Fone,
                    Name = request.Name,
                    Password = password,
                    CreateDate = DateTime.Now,
                };

                _usersRepository.Insert(user);
                _usersRepository.SaveChanges();

                response.StatusCode = 200;
                response.Sucesso = true;
                response.MensagemSucesso = "Usuário criado com sucesso.";
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
