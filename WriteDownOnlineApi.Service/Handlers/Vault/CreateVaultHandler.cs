using MediatR;
using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Enums;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Vault;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.Vault
{
    public class CreateVaultHandler : IRequestHandler<CreateVaultRequest, IOperationResultBase>
    {
        private readonly IVaultRepository _vaultRepository;
        private readonly IUsersRepository _usersRepository;
        public CreateVaultHandler(IVaultRepository vaultRepositpory, IUsersRepository usersRepository)
        {
            _vaultRepository = vaultRepositpory;
            _usersRepository = usersRepository;
        }

        public Task<IOperationResultBase> Handle(CreateVaultRequest request, CancellationToken cancellationToken)
        {
            try
            {

                if (string.IsNullOrEmpty(request.Title))
                    return Task.FromResult(OperationResultBase.CreateInvalidInput().AddMessage("Titulo do vault não pode ser vazio."));

                var user = _usersRepository.GetById(request.CreatedBy);
                if (user == null)
                    return Task.FromResult(OperationResultBase.CreateInvalidInput().AddMessage("Titulo do vault não pode ser vazio."));

                var vault = new VaultEntity()
                {
                    Title = request.Title,
                    CreatedBy = request.CreatedBy,
                    Description = request.Description,
                    IdStatus = (short)EnumStatus.Created,
                    CreateDate = DateTime.Now
                };

                _vaultRepository.Insert(vault);
                _vaultRepository.SaveChanges();

                return Task.FromResult(OperationResultBase.CreateSuccess().AddMessage("Vault criado com sucesso."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex).AddMessage("Ocorreu um erro ao criar o vault."));
            }
        }
    }
}
