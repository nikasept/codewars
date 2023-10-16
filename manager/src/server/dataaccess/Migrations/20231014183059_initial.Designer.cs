﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dataaccess;

#nullable disable

namespace dataaccess.Migrations
{
    [DbContext(typeof(CWDbContext))]
    [Migration("20231014183059_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("domain.models.kata", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("date_creation")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("katas");
                });

            modelBuilder.Entity("domain.models.language", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("date_create")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("path_solutions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("domain.models.solution", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("kataid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("languageid")
                        .HasColumnType("int");

                    b.Property<int>("statusid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("kataid");

                    b.HasIndex("languageid");

                    b.HasIndex("statusid");

                    b.ToTable("solutions");
                });

            modelBuilder.Entity("domain.models.status", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("statuses");
                });

            modelBuilder.Entity("domain.models.solution", b =>
                {
                    b.HasOne("domain.models.kata", "kata")
                        .WithMany()
                        .HasForeignKey("kataid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.models.language", "language")
                        .WithMany()
                        .HasForeignKey("languageid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("domain.models.status", "status")
                        .WithMany()
                        .HasForeignKey("statusid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kata");

                    b.Navigation("language");

                    b.Navigation("status");
                });
#pragma warning restore 612, 618
        }
    }
}
