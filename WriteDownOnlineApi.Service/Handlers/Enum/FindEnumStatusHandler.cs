using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Enum;
using WriteDownOnlineApi.Service.Responses.Enum;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.Enum
{
    public class FindEnumStatusHandler : IRequestHandler<FindEnumStatusRequest, IOperationResult<FindEnumStatusResponse>>
    {
        private readonly IStatusRepository _statusRepository;
        public FindEnumStatusHandler(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public Task<IOperationResult<FindEnumStatusResponse>> Handle(FindEnumStatusRequest request, CancellationToken cancellationToken)
        {
            var response = new FindEnumStatusResponse();
            try
            {
                response.Status = _statusRepository.GetAll().ToList();
                return Task.FromResult(OperationResult<FindEnumStatusResponse>.CreateSuccess(response));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResult<FindEnumStatusResponse>.CreateInternalError(ex).AddMessage("Ocorreu um erro ao buscar os status."));
            }
        }
    }
}
