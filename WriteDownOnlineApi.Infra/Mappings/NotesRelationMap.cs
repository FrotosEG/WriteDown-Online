using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WriteDownOnlineApi.Domain.Entities;

namespace WriteDownOnlineApi.Infra.Mappings
{
    public class NotesRelationMap : IEntityTypeConfiguration<NotesRelationEntity>
    {
        public void Configure(EntityTypeBuilder<NotesRelationEntity> builder)
        {
            builder.ToTable("NotesRelation");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdNoteTo).HasColumnName("IdStatus").HasColumnType("smallint");
            builder.Property(x => x.IdNoteFrom).HasColumnName("IdStatus").HasColumnType("smallint");
            builder.Property(x => x.IdStatus).HasColumnName("IdStatus").HasColumnType("smallint");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate").HasColumnType("timestamp");
            builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate").HasColumnType("timestamp");
            builder.Property(x => x.StatusUpdateDate).HasColumnName("StatusUpdateDate").HasColumnType("timestamp");

            builder.HasOne(d => d.UserTo).WithMany().HasForeignKey(d => d.IdNoteTo);
            builder.HasOne(d => d.UserFrom).WithMany().HasForeignKey(d => d.IdNoteFrom);


        }
    }
}
