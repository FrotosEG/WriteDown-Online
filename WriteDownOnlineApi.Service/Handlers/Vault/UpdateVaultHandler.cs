using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Vault;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.Vault
{
    public class UpdateVaultHandler : IRequestHandler<UpdateVaultRequest, IOperationResultBase>
    {
        private readonly IVaultRepository _vaultRepository;
        public UpdateVaultHandler(IVaultRepository vaultRepositpory)
        {
            _vaultRepository = vaultRepositpory;
        }

        public Task<IOperationResultBase> Handle(UpdateVaultRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var vault = _vaultRepository.GetById(request.IdVault);
                if (vault == null)
                    return Task.FromResult(OperationResultBase.CreateNotFound().AddMessage("Não foi possível encontrar o vault."));

                vault.UpdateDate = DateTime.Now;
                vault.UpdatedBy = request.UpdatedBy;
                vault.Title = request.Title;
                vault.Description = request.Description;
                vault.IdStatus = request.IdStatus;

                _vaultRepository.Update(vault);
                _vaultRepository.SaveChanges();

                return Task.FromResult(OperationResultBase.CreateSuccess().AddMessage("Vault atualizado com sucesso."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex).AddMessage("Ocorreu um erro ao tentar buscar o vault."));
            }
        }
    }
}
