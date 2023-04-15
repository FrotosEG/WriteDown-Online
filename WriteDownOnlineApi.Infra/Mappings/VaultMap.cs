using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WriteDownOnlineApi.Domain.Entities;

namespace WriteDownOnlineApi.Infra.Mappings
{

    public class VaultMap : IEntityTypeConfiguration<VaultEntity>
    {
        public void Configure(EntityTypeBuilder<VaultEntity> builder)
        {
            builder.ToTable("Vault");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar").HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnName("Name").HasColumnType("varchar").HasMaxLength(200);
            builder.Property(x => x.IdStatus).HasColumnName("IdStatus").HasColumnType("smallint");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasColumnType("bigint");
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy").HasColumnType("bigint");
            builder.Property(x => x.StatusChangedBy).HasColumnName("StatusChangedBy").HasColumnType("bigint");
            builder.Property(x => x.StatusUpdateDate).HasColumnName("StatusUpdateDate").HasColumnType("bigint");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate").HasColumnType("timestamp");
            builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate").HasColumnType("timestamp");
            builder.Property(x => x.StatusUpdateDate).HasColumnName("StatusUpdateDate").HasColumnType("timestamp");

            builder.HasOne(d => d.Status).WithMany().HasForeignKey(e => e.IdStatus);
            builder.HasOne(d => d.UsersCreated).WithMany().HasForeignKey(d => d.CreatedBy);
            builder.HasOne(d => d.UsersUpdated).WithMany().HasForeignKey(d => d.UpdatedBy);
            builder.HasOne(d => d.UsersStatus).WithMany().HasForeignKey(d => d.StatusChangedBy);
        }
    }
}
