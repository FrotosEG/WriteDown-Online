using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Responses.Note
{
    public class FindUserNotesResponse : BaseResponse
    {
        public List<NoteEntity> Notes { get; set; }
    }
}
