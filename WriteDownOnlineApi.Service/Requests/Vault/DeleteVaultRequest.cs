using MediatR;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Requests.Vault
{
    public class DeleteVaultRequest : IRequest<BaseResponse>
    {
        public long IdVault { get; set; }
    }
}
