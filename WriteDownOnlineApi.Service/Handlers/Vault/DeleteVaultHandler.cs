using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Vault;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.Vault
{
    public class DeleteVaultHandler : IRequestHandler<DeleteVaultRequest, IOperationResultBase>
    {
        private readonly IVaultRepository _vaultRepository;
        public DeleteVaultHandler(IVaultRepository vaultRepositpory)
        {
            _vaultRepository = vaultRepositpory;
        }

        public Task<IOperationResultBase> Handle(DeleteVaultRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var vault = _vaultRepository.GetById(request.IdVault);
                if (vault == null)
                    return Task.FromResult(OperationResultBase.CreateNotFound().AddMessage("Vault não encontrado."));

                _vaultRepository.Delete(request.IdVault);
                _vaultRepository.SaveChanges();

                return Task.FromResult(OperationResultBase.CreateSuccess().AddMessage("Vault deletado com sucesso."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex).AddMessage("Ocorreu um erro ao deletar o vault."));
            }

        }
    }
}
