using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Note;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.Note
{
    public class UpdateNoteHandler : IRequestHandler<UpdateNoteRequest, IOperationResultBase>
    {
        private readonly INoteRepository _noteRepository;
        public UpdateNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Task<IOperationResultBase> Handle(UpdateNoteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var note = _noteRepository.GetById(request.NoteId);
                if (note == null)
                    return Task.FromResult(OperationResultBase.CreateNotFound().AddMessage("Nota não encontrada."));

                note.IdVault = request.IdVault;
                note.Content = request.Content;
                note.Title = request.Title;
                note.Description = request.Description;
                note.Tags = request.Tags;
                note.UpdatedBy = request.UpdatedBy;
                note.UpdateDate = DateTime.Now;

                _noteRepository.Update(note);
                _noteRepository.SaveChanges();

                return Task.FromResult(OperationResultBase.CreateSuccess().AddMessage("Nota atualizada com sucesso."));

            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex).AddMessage("Ocorreu um erro ao atualizar a nota."));
            }
        }
    }
}
