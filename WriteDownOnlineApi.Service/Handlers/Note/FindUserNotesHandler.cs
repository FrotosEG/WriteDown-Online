using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Note;
using WriteDownOnlineApi.Service.Responses.Note;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.Note
{
    public class FindUserNotesHandler : IRequestHandler<FindUserNotesRequest, IOperationResult<FindUserNotesResponse>>
    {
        private readonly INoteRepository _noteRepository;
        public FindUserNotesHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Task<IOperationResult<FindUserNotesResponse>> Handle(FindUserNotesRequest request, CancellationToken cancellationToken)
        {
            var response = new FindUserNotesResponse();
            try
            {
                response.Notes = _noteRepository.FindUserNotes(request.UserId);
                return Task.FromResult(OperationResult<FindUserNotesResponse>.CreateSuccess(response));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResult<FindUserNotesResponse>.CreateInternalError(ex).AddMessage("Ocorreu um erro ao buscar as notas."));
            }
        }
    }
}
