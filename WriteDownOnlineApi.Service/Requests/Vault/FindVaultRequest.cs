using MediatR;
using WriteDownOnlineApi.Service.Responses.Vault;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.Vault
{
    public class FindVaultRequest : IRequest<IOperationResult<FindVaultReponse>>
    {
        public long IdVault { get; set; }
    }
}
