using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Vault;
using WriteDownOnlineApi.Service.Responses.Vault;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.Vault
{
    public class FindVaultHandler : IRequestHandler<FindVaultRequest, IOperationResult<FindVaultReponse>>
    {
        private readonly IVaultRepository _vaultRepository;
        public FindVaultHandler(IVaultRepository vaultRepositpory)
        {
            _vaultRepository = vaultRepositpory;
        }

        public Task<IOperationResult<FindVaultReponse>> Handle(FindVaultRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var vault = _vaultRepository.GetById(request.IdVault);
                if (vault == null)
                    return Task.FromResult(OperationResult<FindVaultReponse>.CreateNotFound().AddMessage("Vault não encontrado."));

                var response = new FindVaultReponse(vault);

                return Task.FromResult(OperationResult<FindVaultReponse>.CreateSuccess(response));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResult<FindVaultReponse>.CreateInternalError(ex).AddMessage("Ocorreu um erro ao tentar buscar o vault."));
            }
        }
    }
}