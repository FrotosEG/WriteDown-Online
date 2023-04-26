using MediatR;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Requests.Vault
{
    public class CreateVaultRequest : IRequest<BaseResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
    }
}
