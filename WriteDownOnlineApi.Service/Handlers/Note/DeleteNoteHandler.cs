using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Note;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Handlers.Note
{
    internal class DeleteNoteHandler : IRequestHandler<DeleteNoteRequest, BaseResponse>
    {
        private readonly INoteRepository _noteRepository;
        public DeleteNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Task<BaseResponse> Handle(DeleteNoteRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            try
            {
                var note = _noteRepository.GetById(request.NoteId);
                if (note == null)
                {
                    response.StatusCode = 404;
                    response.Sucesso = false;
                    response.MensagemSucesso = $"Nota não encontrada.";
                    return Task.FromResult(response);
                }

                _noteRepository.Delete(note.Id);
                _noteRepository.SaveChanges();

                response.Sucesso = true;
                response.StatusCode = 200;
                response.MensagemSucesso = "Nota deletada com sucesso.";
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
