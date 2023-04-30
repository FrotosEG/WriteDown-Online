using WriteDownOnlineApi.Domain.Entities;

namespace WriteDownOnlineApi.Service.Responses.Note
{
    public class FindUserNotesResponse
    {
        public List<NoteEntity> Notes { get; set; }
    }
}
