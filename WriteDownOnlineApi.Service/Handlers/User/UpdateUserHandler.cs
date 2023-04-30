using MediatR;
using WriteDownOnlineApi.Domain.Dtos;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.User;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.User
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, IOperationResultBase>
    {
        private readonly IUsersRepository _usersRepository;
        public UpdateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public Task<IOperationResultBase> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _usersRepository.GetById(request.UserId);
                if (user == null)
                    return Task.FromResult(OperationResultBase.CreateNotFound().AddMessage("Usuário não encontrado."));

                var password = PasswordHasher.Hash(request.Password);
                user.Password = password;
                user.Name = request.Name;
                user.Email = request.Email;
                user.Fone = request.Fone;

                _usersRepository.Update(user);
                _usersRepository.SaveChanges();

                return Task.FromResult(OperationResultBase.CreateSuccess().AddMessage("Usuário atualizado com sucesso."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex).AddMessage("Ocorreu um erro ao atualizar o usuário."));
            }
        }
    }
}
