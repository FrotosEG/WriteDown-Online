using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WriteDownOnlineApi.Domain.Entities;

namespace WriteDownOnlineApi.Infra.Mappings
{
    public class NoteMap : IEntityTypeConfiguration<NoteEntity>
    {
        public void Configure(EntityTypeBuilder<NoteEntity> builder)
        {
            builder.ToTable("Note");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdVault).HasColumnName("IdVault").HasColumnType("bigint");
            builder.Property(x => x.IdStatus).HasColumnName("IdStatus").HasColumnType("smallint");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasColumnType("bigint");
            builder.Property(x => x.UpdatedBy).HasColumnName("UpdatedBy").HasColumnType("bigint");
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnName("Description").HasColumnType("varchar").HasMaxLength(200);
            builder.Property(x => x.PreviewText).HasColumnName("PreviewText").HasColumnType("varchar").HasMaxLength(200);
            builder.Property(x => x.Tags).HasColumnName("Tags").HasColumnType("varchar").HasMaxLength(200);
            builder.Property(x => x.StatusChangedBy).HasColumnName("StatusChangedBy").HasColumnType("bigint");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate").HasColumnType("timestamp");
            builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate").HasColumnType("timestamp");
            builder.Property(x => x.StatusUpdateDate).HasColumnName("StatusUpdateDate").HasColumnType("timestamp");
          

            builder.HasOne(d => d.Status).WithMany().HasForeignKey(e => e.IdStatus);
            builder.HasOne(d => d.UsersCreated).WithMany().HasForeignKey(d => d.CreatedBy);
            builder.HasOne(d => d.UsersUpdated).WithMany().HasForeignKey(d => d.UpdatedBy);
            builder.HasOne(d => d.UsersStatus).WithMany().HasForeignKey(d => d.StatusChangedBy);
            builder.HasOne(d => d.Vault).WithMany().HasForeignKey(d => d.IdVault);

        }
    }
}
