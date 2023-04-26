using MediatR;
using WriteDownOnlineApi.Service.Responses.Vault;

namespace WriteDownOnlineApi.Service.Requests.Vault
{
    public class FindVaultRequest : IRequest<FindVaultReponse>
    {
        public long IdVault { get; set; }
    }
}
