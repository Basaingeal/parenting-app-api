using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Nursry.Core.Entities;
using Nursry.Core.SharedKernel;
using System;
using System.Linq;

namespace Nursry.Infrastructure.Data
{
    public class NursryContext : DbContext
    {
        public NursryContext(DbContextOptions<NursryContext> options) : base(options)
        {
        }

        public DbSet<Child> Children { get; set; }

        public DbSet<BreastFeedingLog> BreastFeedingLogs { get; set; }
        public DbSet<BottleFeedingLog> BottleFeedingLogs { get; set; }
        public DbSet<DiaperLog> DiaperLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(BaseEntity.Id))
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("NEWSEQUENTIALID()");
            }

            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(Log).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(Log.DateAdded))
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("SYSUTCDATETIME()");
            }

            modelBuilder.Entity<Child>()
                .Property(c => c.DateAdded)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSUTCDATETIME()");

            modelBuilder.Entity<BottleFeedingLog>().Property(fl => fl.Amount).HasColumnType("decimal(8, 5)");
        }
    }
}
