using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Note;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Handlers.Note
{
    internal class UpdateNoteHandler : IRequestHandler<UpdateNoteRequest, BaseResponse>
    {
        private readonly INoteRepository _noteRepository;
        public UpdateNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Task<BaseResponse> Handle(UpdateNoteRequest request, CancellationToken cancellationToken)
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

                note.IdVault = request.IdVault;
                note.Content = request.Content;
                note.Title = request.Title;
                note.Description = request.Description;
                note.Tags = request.Tags;
                note.UpdatedBy = request.UpdatedBy;
                note.UpdateDate = DateTime.Now;

                _noteRepository.Update(note);
                _noteRepository.SaveChanges();

                response.Sucesso = true;
                response.StatusCode = 200;

                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Sucesso = false;
                response.MensagemSucesso = $"Exception: {ex.Message}, Inner: {ex.InnerException?.Message}.";
                return Task.FromResult(response);
            }
        }
    }
}
