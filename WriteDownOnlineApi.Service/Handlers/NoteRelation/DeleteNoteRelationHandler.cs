using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.NoteRelation;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.NoteRelation
{
    public class DeleteNoteRelationHandler : IRequestHandler<DeleteNoteRelationRequest, IOperationResultBase>
    {
        private readonly INotesRelationRepository _notesRelationRepository;
        public DeleteNoteRelationHandler(INotesRelationRepository notesRelationRepository)
        {
            _notesRelationRepository = notesRelationRepository;
        }

        public Task<IOperationResultBase> Handle(DeleteNoteRelationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var noteRelation = _notesRelationRepository.GetById(request.NoteRelationId);
                if (noteRelation == null)
                    return Task.FromResult(OperationResultBase.CreateNotFound().AddMessage("Não foi possível encontrar a relação da nota"));

                _notesRelationRepository.Delete(request.NoteRelationId);
                _notesRelationRepository.SaveChanges();

                return Task.FromResult(OperationResultBase.CreateSuccess().AddMessage("Relação da nota deletada com sucesso."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex).AddMessage("Ocorreu um erro ao atualizar a nota."));
            }
        }
    }
}