using WriteDownOnlineApi.Domain.Entities.Core;

namespace WriteDownOnlineApi.Domain.Entities
{
    public class NotesRelationEntity : BaseEntity<long>
    {
        public long NoteId { get; set; }
        public virtual NoteEntity Note { get; set; }
        public long IdNoteFrom { get; set; }
        public virtual UsersEntity UserFrom { get; set; }
        public long IdNoteTo { get; set; }
        public virtual UsersEntity UserTo { get; set; }
        public short IdStatus { get; set; }
        public virtual StatusEntity Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime StatusUpdateDate { get; set; }
    }
}
