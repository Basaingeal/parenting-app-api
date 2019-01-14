using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Nursry.Core;
using Nursry.Core.Entities;
using Nursry.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nursry.Infrastructure.Data
{
    public class NursryContext : DbContext
    {
        public NursryContext(DbContextOptions<NursryContext> options) : base(options)
        {
        }

        public DbSet<Child> Children { get; set; }
        public DbSet<Gender> Genders { get; set; }


        public DbSet<FeedingLog> FeedingLogs { get; set; }
        public DbSet<BottleFeedingLog> BottleFeedingLogs { get; set; }
        public DbSet<FeedingType> FeedingTypes { get; set; }
        public DbSet<BottleContent> BottleContents { get; set; }

        public DbSet<DiaperLog> DiaperLogs { get; set; }
        public DbSet<DiaperType> DiaperTypes { get; set; }

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

            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
                            new Gender {
                                Id = Guid.NewGuid(),
                                Title = "Male"
                            },
                            new Gender
                            {
                                Id = Guid.NewGuid(),
                                Title = "Female"
                            }
            );

            modelBuilder.Entity<FeedingType>().HasData(
                new FeedingType { Id = Guid.NewGuid(), Type = "Left Breast" },
                new FeedingType { Id = Guid.NewGuid(), Type = "Right Breast" },
                new FeedingType { Id = Guid.NewGuid(), Type = "Bottle" },
                new FeedingType { Id = Guid.NewGuid(), Type = "Meal" }
            );

            modelBuilder.Entity<BottleContent>().HasData(
                new BottleContent { Id = Guid.NewGuid(), Content = "Formula" },
                new BottleContent { Id = Guid.NewGuid(), Content = "Breast milk" }
            );

            modelBuilder.Entity<DiaperType>().HasData(
                new DiaperType { Id = Guid.NewGuid(), Title = "Pee" },
                new DiaperType { Id = Guid.NewGuid(), Title = "Poo" },
                new DiaperType { Id = Guid.NewGuid(), Title = "Both" }
            );
        }
    }
}
