﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nursry.Infrastructure.Data;

namespace Nursry.Infrastructure.Data.Migrations
{
    [DbContext(typeof(NursryContext))]
    partial class NursryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Nursry.Core.Entities.Child", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("ImageUri");

                    b.Property<string>("LastName");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("Nursry.Core.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid?>("ChildId");

                    b.Property<string>("Details");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.ToTable("Log");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Log");
                });

            modelBuilder.Entity("Nursry.Core.Entities.DiaperLog", b =>
                {
                    b.HasBaseType("Nursry.Core.Entities.Log");

                    b.Property<int>("DiaperType");

                    b.Property<DateTime>("TimeOfDiaperChange");

                    b.HasDiscriminator().HasValue("DiaperLog");
                });

            modelBuilder.Entity("Nursry.Core.Entities.FeedingLog", b =>
                {
                    b.HasBaseType("Nursry.Core.Entities.Log");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(8, 5)");

                    b.Property<int?>("Contents");

                    b.Property<DateTime>("EndTime");

                    b.Property<int>("FeedingType");

                    b.Property<DateTime>("StartTime");

                    b.HasDiscriminator().HasValue("FeedingLog");
                });

            modelBuilder.Entity("Nursry.Core.Entities.Log", b =>
                {
                    b.HasOne("Nursry.Core.Entities.Child", "Child")
                        .WithMany("Logs")
                        .HasForeignKey("ChildId");
                });
#pragma warning restore 612, 618
        }
    }
}
