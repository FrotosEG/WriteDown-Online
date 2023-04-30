using MediatR;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.Vault
{
    public class DeleteVaultRequest : IRequest<IOperationResultBase>
    {
        public long IdVault { get; set; }
    }
}
