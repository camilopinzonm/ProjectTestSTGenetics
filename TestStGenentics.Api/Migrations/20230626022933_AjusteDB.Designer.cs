﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestStGenentics.Api.Data;

#nullable disable

namespace TestStGenentics.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230626022933_AjusteDB")]
    partial class AjusteDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestStGenentics.Shared.Entities.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnimalId"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BreedId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SexId")
                        .HasColumnType("int");

                    b.Property<int>("StatusRowId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId");

                    b.HasIndex("AnimalId")
                        .IsUnique();

                    b.HasIndex("BreedId");

                    b.HasIndex("SexId");

                    b.HasIndex("StatusRowId");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("TestStGenentics.Shared.Entities.Breed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Breeds");
                });

            modelBuilder.Entity("TestStGenentics.Shared.Entities.Sex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Sexs");
                });

            modelBuilder.Entity("TestStGenentics.Shared.Entities.StatusRow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("StatusRows");
                });

            modelBuilder.Entity("TestStGenentics.Shared.Entities.Animal", b =>
                {
                    b.HasOne("TestStGenentics.Shared.Entities.Breed", "Breed")
                        .WithMany("Animal")
                        .HasForeignKey("BreedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestStGenentics.Shared.Entities.Sex", "Sex")
                        .WithMany("Animal")
                        .HasForeignKey("SexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestStGenentics.Shared.Entities.StatusRow", "StatusRow")
                        .WithMany("Animal")
                        .HasForeignKey("StatusRowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breed");

                    b.Navigation("Sex");

                    b.Navigation("StatusRow");
                });

            modelBuilder.Entity("TestStGenentics.Shared.Entities.Breed", b =>
                {
                    b.Navigation("Animal");
                });

            modelBuilder.Entity("TestStGenentics.Shared.Entities.Sex", b =>
                {
                    b.Navigation("Animal");
                });

            modelBuilder.Entity("TestStGenentics.Shared.Entities.StatusRow", b =>
                {
                    b.Navigation("Animal");
                });
#pragma warning restore 612, 618
        }
    }
}
