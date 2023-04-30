using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.NoteRelation;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.NoteRelation
{
    public class UpdateNoteRelationHandler : IRequestHandler<UpdateNoteRelationRequest, IOperationResultBase>
    {
        private readonly INotesRelationRepository _notesRelationRepository;
        public UpdateNoteRelationHandler(INotesRelationRepository notesRelationRepository)
        {
            _notesRelationRepository = notesRelationRepository;
        }

        public Task<IOperationResultBase> Handle(UpdateNoteRelationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var noteRelation = _notesRelationRepository.GetById(request.NoteRelationId);
                if (noteRelation == null)
                    return Task.FromResult(OperationResultBase.CreateNotFound().AddMessage("Não foi possível encontrar a relação."));

                noteRelation.IdNoteFrom = request.IdNoteFrom;
                noteRelation.IdNoteTo = request.IdNoteTo;
                if (noteRelation.IdStatus != request.IdStatus)
                {
                    noteRelation.IdStatus = request.IdStatus;
                    noteRelation.StatusUpdateDate = DateTime.Now;
                }
                noteRelation.UpdateDate = DateTime.Now;

                _notesRelationRepository.Update(noteRelation);
                _notesRelationRepository.SaveChanges();

                return Task.FromResult(OperationResultBase.CreateSuccess());
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex));

            }
        }
    }
}
