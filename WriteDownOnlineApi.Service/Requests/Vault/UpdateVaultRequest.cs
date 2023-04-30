using MediatR;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.Vault
{
    public class UpdateVaultRequest : IRequest<IOperationResultBase>
    {
        public long IdVault { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short IdStatus { get; set; }
        public long UpdatedBy { get; set; }
    }
}
