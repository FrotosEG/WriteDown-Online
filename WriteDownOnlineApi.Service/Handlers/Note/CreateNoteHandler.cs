using MediatR;
using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Enums;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Note;
using WriteDownOnlineApi.Util.Interfaces.Results;
using WriteDownOnlineApi.Util.Models;

namespace WriteDownOnlineApi.Service.Handlers.Note
{
    public class CreateNoteHandler : IRequestHandler<CreateNoteRequest, IOperationResultBase>
    {
        private readonly INoteRepository _noteRepository;
        public CreateNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Task<IOperationResultBase> Handle(CreateNoteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var note = new NoteEntity()
                {
                    IdVault = request.IdVault,
                    IdStatus = (short)EnumStatus.Created,
                    Content = "",
                    CreateDate = DateTime.Now,
                    CreatedBy = request.UserId,
                    PreviewText = "",
                    Description = request.Description,
                    Tags = request.Tags,
                    Title = request.Title,
                };

                _noteRepository.Insert(note);
                _noteRepository.SaveChanges();

                return Task.FromResult(OperationResultBase.CreateSuccess().AddMessage("Nota criada com sucesso."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(OperationResultBase.CreateInternalError(ex).AddMessage("Ocorreu um erro ao criar a nota."));
            }
        }
    }
}
