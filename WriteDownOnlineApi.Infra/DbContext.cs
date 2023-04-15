using Microsoft.EntityFrameworkCore;
using WriteDownOnlineApi.Infra.Mappings;

namespace WriteDownOnlineApi.Infra
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsersMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
