using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Note;
using WriteDownOnlineApi.Service.Responses.Note;

namespace WriteDownOnlineApi.Service.Handlers.Note
{
    public class FindUserNotesHandler : IRequestHandler<FindUserNotesRequest, FindUserNotesResponse>
    {
        private readonly INoteRepository _noteRepository;
        public FindUserNotesHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Task<FindUserNotesResponse> Handle(FindUserNotesRequest request, CancellationToken cancellationToken)
        {
            var response = new FindUserNotesResponse();
            try
            {
                response.Notes = _noteRepository.FindUserNotes(request.UserId);
                response.Sucesso = true;
                response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Sucesso = false;
                response.MensagemSucesso = $"Exception: {ex.Message}, Inner: {ex.InnerException?.Message}.";
            }
            return Task.FromResult(response);

        }
    }
}
