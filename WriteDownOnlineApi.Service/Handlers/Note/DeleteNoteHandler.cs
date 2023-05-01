using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Note;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.Note
{
    public class DeleteNoteHandler : IRequestHandler<DeleteNoteRequest, IOperationResultBase>
    {
        private readonly INoteRepository _noteRepository;
        public DeleteNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Task<IOperationResultBase> Handle(DeleteNoteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var note = _noteRepository.GetById(request.NoteId);
                if (note == null)
                {
                    return Task.FromResult(OperationResultBase.CreateNotFound().AddMessage("Nota não encontrada."));

                }

                _noteRepository.Delete(note.Id);
                _noteRepository.SaveChanges();


                return Task.FromResult(OperationResultBase.CreateSuccess().AddMessage("Nota criada com sucesso."));

            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex).AddMessage("Ocorreu um erro ao deletar a nota."));
            }
        }
    }
}
