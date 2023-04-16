using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WriteDownOnlineApi.Domain.Entities;
using WriteDownOnlineApi.Infra.Mappings;

namespace WriteDownOnlineApi.Infra
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UsersEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteMap());
            modelBuilder.ApplyConfiguration(new NotesRelationMap());
            modelBuilder.ApplyConfiguration(new RelationUserVaultMap());
            modelBuilder.ApplyConfiguration(new StatusMap());
            modelBuilder.ApplyConfiguration(new UsersMap());
            modelBuilder.ApplyConfiguration(new VaultMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
