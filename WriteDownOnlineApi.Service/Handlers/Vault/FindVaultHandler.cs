using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Vault;
using WriteDownOnlineApi.Service.Responses.Vault;

namespace WriteDownOnlineApi.Service.Handlers.Vault
{
    public class FindVaultHandler : IRequestHandler<FindVaultRequest, FindVaultReponse>
    {
        private readonly IVaultRepository _vaultRepository;
        public FindVaultHandler(IVaultRepository vaultRepositpory)
        {
            _vaultRepository = vaultRepositpory;
        }

        public Task<FindVaultReponse> Handle(FindVaultRequest request, CancellationToken cancellationToken)
        {
            var response = new FindVaultReponse();
            try
            {
                var vault = _vaultRepository.GetById(request.IdVault);
                if (vault == null)
                {
                    response.StatusCode = 404;
                    response.MensagemSucesso = "Vault não encontrado.";
                    response.Sucesso = false;
                    return Task.FromResult(response);
                }
                response = new FindVaultReponse(vault);
                response.StatusCode = 200;
                response.MensagemSucesso = "Vault encontrado com sucesso.";
                response.Sucesso = true;

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