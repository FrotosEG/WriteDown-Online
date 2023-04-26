using WriteDownOnlineApi.Domain.Entities.Core;
using WriteDownOnlineApi.Domain.Enums;

namespace WriteDownOnlineApi.Domain.Entities
{
    public class VaultEntity : BaseEntity<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public short IdStatus { get; set; }
        public virtual StatusEntity Status { get; set; }
        public long CreatedBy { get; set; }
        public virtual UsersEntity UsersCreated { get; set; }
        public long UpdatedBy { get; set; }
        public virtual UsersEntity UsersUpdated { get; set; }
        public long StatusChangedBy { get; set; }
        public virtual UsersEntity UsersStatus { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime StatusUpdateDate { get; set; }
    }
}
