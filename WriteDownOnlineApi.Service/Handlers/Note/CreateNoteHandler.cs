using MediatR;
using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Domain.Enums;
using WriteDownOnlineApi.Domain.Interface;
using WriteDownOnlineApi.Service.Requests.Note;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Handlers.Note
{
    public class CreateNoteHandler : IRequestHandler<CreateNoteRequest, BaseResponse>
    {
        private readonly INoteRepository _noteRepository;
        public CreateNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Task<BaseResponse> Handle(CreateNoteRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
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
                    Title= request.Title,
                };

                _noteRepository.Insert(note);
                _noteRepository.SaveChanges();

                response.StatusCode = 200;
                response.Sucesso = true;
                response.MensagemSucesso = "Nota criada com sucesso.";

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
