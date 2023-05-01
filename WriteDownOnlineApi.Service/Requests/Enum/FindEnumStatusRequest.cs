using MediatR;
using WriteDownOnlineApi.Service.Responses.Enum;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.Enum
{
    public class FindEnumStatusRequest : IRequest<IOperationResult<FindEnumStatusResponse>>
    {
    }
}
