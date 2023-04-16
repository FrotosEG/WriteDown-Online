using WriteDownOnlineApi.Domain.Entities.Core;
using WriteDownOnlineApi.Domain.Enums;

namespace WriteDownOnlineApi.Domain.Entities
{
    public class RelationUsersVaultEntity : BaseEntity<long>
    {
        public long IdUser { get; set; }
        public virtual UsersEntity User { get; set; }
        public long IdVault { get; set; }
        public virtual VaultEntity Vault { get; set; }
        public short IdStatus { get; set; }
        public virtual StatusEntity Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? StatusUpdateDate { get; set; }

    }
}
