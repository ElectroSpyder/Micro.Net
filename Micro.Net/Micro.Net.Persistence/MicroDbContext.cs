using Micro.Net.Domain.Common;
using Micro.Net.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Micro.Net.Persistence
{
    public class MicroDbContext : DbContext
    {
        public MicroDbContext(DbContextOptions<MicroDbContext> dbContextOptions) : base(dbContextOptions)
        {  }

        public DbSet<UserEntity> MyProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            //aqui buscará todas las configuraciones en el asembly y las aplicara
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MicroDbContext).Assembly);

            var usertGuid = Guid.Parse("{252dt73-78ee-4fec-b181-3229219270be}");

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = usertGuid,

            });

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //codigo adicional para actualizar las propiedades
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
    
