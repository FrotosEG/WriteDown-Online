using MediatR;
using WriteDownOnlineApi.Util.Interfaces.Results;

namespace WriteDownOnlineApi.Service.Requests.Note
{
    public class CreateNoteRequest : IRequest<IOperationResultBase>
    {
        public long UserId { get; set; }
        public long IdVault { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
    }
}
