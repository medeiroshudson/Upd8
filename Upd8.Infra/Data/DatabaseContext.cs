using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Upd8.Domain.Entities;
using Upd8.Domain.Core.Entities;

namespace Upd8.Infra.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; } = null!;

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is Entity)
                .ToList();

            UpdateTimestamps(entries);
            ConfigureSoftDelete(entries);

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        private static void ConfigureSoftDelete(List<EntityEntry> entries)
        {
            var filteredEntities = entries.Where(x =>
                    x.State == EntityState.Added ||
                    x.State == EntityState.Deleted
                );

            foreach (var entry in filteredEntities)
            {
                if (entry.State == EntityState.Added)
                {
                    ((Entity)entry.Entity).Deleted = false;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    ((Entity)entry.Entity).Deleted = true;
                    ((Entity)entry.Entity).UpdatedAt = DateTime.Now;
                }
            }
        }

        private static void UpdateTimestamps(List<EntityEntry> entries)
        {
            var filteredEntities = entries.Where(x =>
                    x.State == EntityState.Added ||
                    x.State == EntityState.Modified
                );

            foreach (var entry in filteredEntities)
            {
                if (entry.State == EntityState.Added)
                {
                    ((Entity)entry.Entity).CreatedAt = DateTime.Now;
                }

                ((Entity)entry.Entity).UpdatedAt = DateTime.Now;
            }
        }
    }
}
