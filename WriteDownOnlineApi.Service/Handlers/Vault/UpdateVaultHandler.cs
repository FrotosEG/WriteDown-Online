using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Vault;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Handlers.Vault
{
    public class UpdateVaultHandler : IRequestHandler<UpdateVaultRequest, BaseResponse>
    {
        private readonly IVaultRepository _vaultRepository;
        public UpdateVaultHandler(IVaultRepository vaultRepositpory)
        {
            _vaultRepository = vaultRepositpory;
        }

        public Task<BaseResponse> Handle(UpdateVaultRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                var vault = _vaultRepository.GetById(request.IdVault);
                if (vault == null)
                {
                    response.StatusCode = 400;
                    response.MensagemSucesso = "Vault não existe.";
                    response.Sucesso = false;
                    return Task.FromResult(response);
                }

                vault.UpdateDate = DateTime.Now;
                vault.UpdatedBy = request.UpdatedBy;
                vault.Title = request.Title;
                vault.Description = request.Description;
                vault.IdStatus = request.IdStatus;

                _vaultRepository.Update(vault);
                _vaultRepository.SaveChanges();

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
