using MediatR;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.NoteRelation;
using WriteDownOnlineApi.Service.Responses.Core;
using WriteDownOnlineApi.Service.Responses.NoteRelation;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.NoteRelation
{
    public class FindNoteRelationHandler : IRequestHandler<FindNoteRelationRequest, IOperationResult<List<FindNoteRelationResponse>>>
    {
        private readonly INotesRelationRepository _notesRelationRepository;
        public FindNoteRelationHandler(INotesRelationRepository notesRelationRepository)
        {
            _notesRelationRepository = notesRelationRepository;
        }

        public Task<IOperationResult<List<FindNoteRelationResponse>>> Handle(FindNoteRelationRequest request, CancellationToken cancellationToken)
        {
            var response = new List<FindNoteRelationResponse>();
            try
            {
                var notes = _notesRelationRepository.GetNotesRelationByIdNote(request.NoteId);


                return Task.FromResult(OperationResult<List<FindNoteRelationResponse>>.CreateSuccess(response));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResult<List<FindNoteRelationResponse>>.CreateInternalError(ex));

            }

        }
    }
}