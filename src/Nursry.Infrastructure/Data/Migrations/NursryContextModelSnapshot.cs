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

            modelBuilder.Entity("Nursry.Core.Entities.BottleContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.HasKey("Id");

                    b.ToTable("BottleContents");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8c0544b5-3fdd-4f48-ab4e-a2820196f5d8"),
                            Content = "Formula"
                        },
                        new
                        {
                            Id = new Guid("79ea25f4-7b1f-48e8-8fdc-78894b871083"),
                            Content = "Breast milk"
                        });
                });

            modelBuilder.Entity("Nursry.Core.Entities.Child", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<Guid?>("GenderId");

                    b.Property<string>("ImageUri");

                    b.Property<string>("LastName");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Children");
                });

            modelBuilder.Entity("Nursry.Core.Entities.DiaperType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("DiaperTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1206a261-8ea0-4d88-b427-e8c41057fb5f"),
                            Title = "Pee"
                        },
                        new
                        {
                            Id = new Guid("a3a499c5-b271-4540-a913-fb1cdbf542a3"),
                            Title = "Poo"
                        },
                        new
                        {
                            Id = new Guid("79640e24-1a12-4121-99ab-943f55fcdb90"),
                            Title = "Both"
                        });
                });

            modelBuilder.Entity("Nursry.Core.Entities.FeedingType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("FeedingTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9384fdce-898d-4c65-8007-014bdae60487"),
                            Type = "Left Breast"
                        },
                        new
                        {
                            Id = new Guid("2f9622c6-128d-43cd-ba3b-3c685e905f98"),
                            Type = "Right Breast"
                        },
                        new
                        {
                            Id = new Guid("2588236e-f2f7-4a39-8a16-348a15b94041"),
                            Type = "Bottle"
                        },
                        new
                        {
                            Id = new Guid("22fc12b5-92ef-4b88-b5aa-7d50c6523ebb"),
                            Type = "Meal"
                        });
                });

            modelBuilder.Entity("Nursry.Core.Entities.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Genders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("246f4ecf-0268-4a69-a14f-93221658b29c"),
                            Title = "Male"
                        },
                        new
                        {
                            Id = new Guid("6b852f22-9419-4125-8e5a-6914049bed85"),
                            Title = "Female"
                        });
                });

            modelBuilder.Entity("Nursry.Core.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ChildId");

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

                    b.Property<Guid?>("DiaperTypeId");

                    b.Property<DateTime>("TimeOfDiaperChange");

                    b.HasIndex("DiaperTypeId");

                    b.HasDiscriminator().HasValue("DiaperLog");
                });

            modelBuilder.Entity("Nursry.Core.Entities.FeedingLog", b =>
                {
                    b.HasBaseType("Nursry.Core.Entities.Log");

                    b.Property<string>("Details");

                    b.Property<DateTime>("EndTime");

                    b.Property<Guid?>("FeedingTypeId");

                    b.Property<DateTime>("StartTime");

                    b.HasIndex("FeedingTypeId");

                    b.HasDiscriminator().HasValue("FeedingLog");
                });

            modelBuilder.Entity("Nursry.Core.Entities.BottleFeedingLog", b =>
                {
                    b.HasBaseType("Nursry.Core.Entities.FeedingLog");

                    b.Property<decimal>("Amount");

                    b.Property<Guid?>("ContentsId");

                    b.HasIndex("ContentsId");

                    b.HasDiscriminator().HasValue("BottleFeedingLog");
                });

            modelBuilder.Entity("Nursry.Core.Entities.Child", b =>
                {
                    b.HasOne("Nursry.Core.Entities.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");
                });

            modelBuilder.Entity("Nursry.Core.Entities.Log", b =>
                {
                    b.HasOne("Nursry.Core.Entities.Child", "Child")
                        .WithMany("Logs")
                        .HasForeignKey("ChildId");
                });

            modelBuilder.Entity("Nursry.Core.Entities.DiaperLog", b =>
                {
                    b.HasOne("Nursry.Core.Entities.DiaperType", "DiaperType")
                        .WithMany()
                        .HasForeignKey("DiaperTypeId");
                });

            modelBuilder.Entity("Nursry.Core.Entities.FeedingLog", b =>
                {
                    b.HasOne("Nursry.Core.Entities.FeedingType", "FeedingType")
                        .WithMany()
                        .HasForeignKey("FeedingTypeId");
                });

            modelBuilder.Entity("Nursry.Core.Entities.BottleFeedingLog", b =>
                {
                    b.HasOne("Nursry.Core.Entities.BottleContent", "Contents")
                        .WithMany()
                        .HasForeignKey("ContentsId");
                });
#pragma warning restore 612, 618
        }
    }
}
