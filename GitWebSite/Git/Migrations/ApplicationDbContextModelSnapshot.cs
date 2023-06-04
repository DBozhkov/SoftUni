﻿// <auto-generated />
using System;
using Git.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Git.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Git.Data.Models.Commit", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("CreatorId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("RepositoryId");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("RepositoryId");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("Git.Data.Models.Repository", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsPublic");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("OwnerId");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Repositories");
                });

            modelBuilder.Entity("Git.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Git.Data.Models.Commit", b =>
                {
                    b.HasOne("Git.Data.Models.User", "Creator")
                        .WithMany("Commits")
                        .HasForeignKey("CreatorId");

                    b.HasOne("Git.Data.Models.Repository", "Repository")
                        .WithMany("Commits")
                        .HasForeignKey("RepositoryId");
                });

            modelBuilder.Entity("Git.Data.Models.Repository", b =>
                {
                    b.HasOne("Git.Data.Models.User", "Owner")
                        .WithMany("Repositories")
                        .HasForeignKey("OwnerId");
                });
#pragma warning restore 612, 618
        }
    }
}
