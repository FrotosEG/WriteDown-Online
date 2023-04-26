using MediatR;
using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Enums;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Vault;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Handlers.Vault
{
    public class CreateVaultHandler : IRequestHandler<CreateVaultRequest, BaseResponse>
    {
        private readonly IVaultRepository _vaultRepository;
        private readonly IUsersRepository _usersRepository;
        public CreateVaultHandler(IVaultRepository vaultRepositpory, IUsersRepository usersRepository)
        {
            _vaultRepository = vaultRepositpory;
            _usersRepository = usersRepository;
        }

        public Task<BaseResponse> Handle(CreateVaultRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                if (string.IsNullOrEmpty(request.Title))
                {
                    response.StatusCode = 400;
                    response.MensagemSucesso = "É necessário um título para a criação do Vault.";
                    response.Sucesso = false;
                    return Task.FromResult(response);
                }

                var user = _usersRepository.GetById(request.CreatedBy);
                if (user == null)
                {
                    response.StatusCode = 400;
                    response.MensagemSucesso = "O usuário não existe.";
                    response.Sucesso = false;
                    return Task.FromResult(response);
                }

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
