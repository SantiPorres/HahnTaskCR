using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Common;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
            ) : base( options )
        {

        }
        
        public virtual DbSet<Card> Cards { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow; 
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
