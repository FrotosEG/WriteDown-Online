using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WriteDownOnlineApi.Domain.Entities;

namespace WriteDownOnlineApi.Infra.Mappings
{
    public class RelationUserVaultMap : IEntityTypeConfiguration<RelationUsersVaultEntity>
    {
        public void Configure(EntityTypeBuilder<RelationUsersVaultEntity> builder)
        {
            builder.ToTable("RelationUsersVault");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdUser).HasColumnName("IdUser").HasColumnType("bigint");
            builder.Property(x => x.IdVault).HasColumnName("IdVault").HasColumnType("bigint");
            builder.Property(x => x.IdStatus).HasColumnName("IdStatus").HasColumnType("smallint");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate").HasColumnType("timestamp");
            builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate").HasColumnType("timestamp");
            builder.Property(x => x.StatusUpdateDate).HasColumnName("StatusUpdateDate").HasColumnType("timestamp");
        }
    }
}
