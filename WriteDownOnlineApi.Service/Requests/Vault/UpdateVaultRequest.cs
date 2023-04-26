using MediatR;
using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Requests.Vault
{
    public class UpdateVaultRequest : IRequest<BaseResponse>
    {
        public long IdVault { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short IdStatus { get; set; }
        public long UpdatedBy { get; set; }
    }
}
