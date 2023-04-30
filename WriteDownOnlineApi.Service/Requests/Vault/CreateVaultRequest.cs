using MediatR;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.Vault
{
    public class CreateVaultRequest : IRequest<IOperationResultBase>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long CreatedBy { get; set; }
    }
}
