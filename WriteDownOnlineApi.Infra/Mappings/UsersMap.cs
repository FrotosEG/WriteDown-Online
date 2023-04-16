using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WriteDownOnlineApi.Domain.Entities;

namespace WriteDownOnlineApi.Infra.Mappings
{
    public class UsersMap : IEntityTypeConfiguration<UsersEntity>
    {
        public void Configure(EntityTypeBuilder<UsersEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("varchar").HasMaxLength(200);
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("varchar").HasMaxLength(150);
            builder.Property(x => x.Fone).HasColumnName("Fone").HasColumnType("varchar").HasMaxLength(15);
            builder.Property(x => x.Password).HasColumnName("Password").HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.IdStatus).HasColumnName("IdStatus").HasColumnType("smallint");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate").HasColumnType("timestamp");
            builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate").HasColumnType("timestamp");
            builder.Property(x => x.StatusUpdateDate).HasColumnName("StatusUpdateDate").HasColumnType("timestamp");

            builder.HasOne(d => d.Status).WithMany().HasForeignKey(e => e.IdStatus);
        }
    }
}
