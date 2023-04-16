using WriteDownOnlineApi.Domain.Entities.Core;
using WriteDownOnlineApi.Domain.Enums;

namespace WriteDownOnlineApi.Domain.Entities
{
    public class NoteEntity : BaseEntity<long>
    {
        public long IdVault { get; set; }
        public virtual VaultEntity Vault { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PreviewText { get; set; }
        public short? IdStatus { get; set; }
        public virtual StatusEntity Status { get; set; }
        public string Tags { get; set; }
        public long? CreatedBy { get; set; }
        public virtual UsersEntity UsersCreated { get; set; }
        public long? UpdatedBy { get; set; }
        public virtual UsersEntity UsersUpdated { get; set; }
        public long? StatusChangedBy { get; set; }
        public virtual UsersEntity UsersStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? StatusUpdateDate { get; set; }
    }
}
