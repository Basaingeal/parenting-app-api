using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Nursry.Core.Entities;
using Nursry.Core.SharedKernel;
using System.Linq;

namespace Nursry.Infrastructure.Data
{
    public class NursryContext : DbContext
    {
        public NursryContext(DbContextOptions<NursryContext> options) : base(options)
        {
        }

        public DbSet<Child> Children { get; set; }

        public DbSet<FeedingLog> FeedingLogs { get; set; }
        public DbSet<DiaperLog> DiaperLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property(nameof(BaseEntity.Id))
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("newsequentialid()");
            }

            modelBuilder.Entity<FeedingLog>().Property(fl => fl.Amount).HasColumnType("decimal(8, 5)");
        }
    }
}
