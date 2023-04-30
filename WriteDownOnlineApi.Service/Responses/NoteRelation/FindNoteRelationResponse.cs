using WriteDownOnlineApi.Service.Responses.Core;

namespace WriteDownOnlineApi.Service.Responses.NoteRelation
{
    public class FindNoteRelationResponse : BaseResponse
    {
        public long IdNoteFrom { get; set; }
        public long IdNoteTo { get; set; }
        public short IdStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime StatusUpdateDate { get; set; }
    }
}
