using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WriteDownOnlineApi.Domain.Entities;

namespace WriteDownOnlineApi.Infra.Mappings
{

    public class StatusMap : IEntityTypeConfiguration<StatusEntity>
    {
        public void Configure(EntityTypeBuilder<StatusEntity> builder)
        {
            builder.ToTable("EnumStatus");
            builder.HasKey(x => x.Id);
        }
    }
}
