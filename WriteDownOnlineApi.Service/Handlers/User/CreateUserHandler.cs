using MediatR;
using WriteDownOnlineApi.Domain.Dtos;
using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Enums;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.User;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.User
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, IOperationResultBase>
    {
        private readonly IUsersRepository _usersRepository;
        public CreateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<IOperationResultBase> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                string password = "";
                if (String.IsNullOrEmpty(request.Password))
                    return Task.FromResult(OperationResultBase.CreateInvalidInput().AddMessage("Senha não pode estar vazia."));

                if (String.IsNullOrEmpty(request.Email))
                    return Task.FromResult(OperationResultBase.CreateInvalidInput().AddMessage("Email não pode estar vazio."));

                if (String.IsNullOrEmpty(request.Fone))
                    return Task.FromResult(OperationResultBase.CreateInvalidInput().AddMessage("Telefone não pode estar vazio."));

                if (String.IsNullOrEmpty(request.Name))
                    return Task.FromResult(OperationResultBase.CreateInvalidInput().AddMessage("Nome não pode estar vazio."));

                //verify if email already exists in DB
                var existingEmail = _usersRepository.FindUserByEmail(request.Email);
                if (existingEmail != null)
                    return Task.FromResult(OperationResultBase.CreateInvalidInput().AddMessage("O email já está cadastrado."));

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

                return Task.FromResult(OperationResultBase.CreateSuccess().AddMessage("Usuário criado com sucesso."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex).AddMessage("Ocorreu um erro ao cadastrar o usuário."));

            }

        }
    }
}
