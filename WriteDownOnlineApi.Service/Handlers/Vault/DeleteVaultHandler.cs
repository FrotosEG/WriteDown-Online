using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Vault;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Handlers.Vault
{
    public class DeleteVaultHandler : IRequestHandler<DeleteVaultRequest, BaseResponse>
    {
        private readonly IVaultRepository _vaultRepository;
        public DeleteVaultHandler(IVaultRepository vaultRepositpory)
        {
            _vaultRepository = vaultRepositpory;
        }

        public Task<BaseResponse> Handle(DeleteVaultRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                var vault = _vaultRepository.GetById(request.IdVault);
                if(vault == null)
                {
                    response.StatusCode = 400;
                    response.MensagemSucesso = "Vault não existe.";
                    response.Sucesso = false;
                    return Task.FromResult(response);
                }

                _vaultRepository.Delete(request.IdVault);
                _vaultRepository.SaveChanges();

                response.StatusCode = 200;
                response.MensagemSucesso = "Vault deletado com sucesso.";
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
