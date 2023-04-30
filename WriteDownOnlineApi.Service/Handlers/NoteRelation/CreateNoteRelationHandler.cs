using MediatR;
using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.NoteRelation;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.NoteRelation
{
    public class CreateNoteRelationHandler : IRequestHandler<CreateNoteRelationRequest, IOperationResultBase>
    {
        private readonly INotesRelationRepository _notesRelationRepository;
        private readonly IUsersRepository _usersRepository;
        public CreateNoteRelationHandler(INotesRelationRepository notesRelationRepository, IUsersRepository usersRepository)
        {
            _notesRelationRepository = notesRelationRepository;
            _usersRepository = usersRepository;
        }

        public Task<IOperationResultBase> Handle(CreateNoteRelationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var userTo = _usersRepository.GetById(request.IdNoteTo);
                if (userTo == null)
                    return Task.FromResult(OperationResultBase.CreateNotFound().AddMessage("Não existe um usuário para criar a relação da nota."));

                var userFrom = _usersRepository.GetById(request.IdNoteFrom);
                if (userFrom == null)
                    return Task.FromResult(OperationResultBase.CreateNotFound().AddMessage("Não existe um usuário para criar a relação da nota."));

                var noteRelation = new NotesRelationEntity()
                {
                    CreateDate = DateTime.Now,
                    IdNoteFrom = request.IdNoteFrom,
                    IdNoteTo = request.IdNoteTo,
                    IdStatus = request.IdStatus,
                };

                _notesRelationRepository.Insert(noteRelation);
                _notesRelationRepository.SaveChanges();

                return Task.FromResult(OperationResultBase.CreateSuccess().AddMessage("Relação de nota criada com sucesso."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex).AddMessage("Ocorreu um erro ao criar a relação da nota."));
            }
        }
    }
}

