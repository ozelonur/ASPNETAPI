﻿// <auto-generated />
using System;
using KPSS.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KPSS.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240126220033_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KPSS.Core.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Pencils"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Books"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Notebooks"
                        });
                });

            modelBuilder.Entity("KPSS.Core.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 1, 27, 1, 0, 33, 528, DateTimeKind.Local).AddTicks(9660),
                            Name = "Pencil 1",
                            Price = 100m,
                            Stock = 20
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 1, 27, 1, 0, 33, 528, DateTimeKind.Local).AddTicks(9680),
                            Name = "Pencil 2",
                            Price = 200m,
                            Stock = 30
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 1, 27, 1, 0, 33, 528, DateTimeKind.Local).AddTicks(9690),
                            Name = "Book 1",
                            Price = 300m,
                            Stock = 50
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2024, 1, 27, 1, 0, 33, 528, DateTimeKind.Local).AddTicks(9690),
                            Name = "Book 2",
                            Price = 700m,
                            Stock = 10
                        });
                });

            modelBuilder.Entity("KPSS.Core.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "Red",
                            Height = 100,
                            ProductId = 1,
                            Width = 200
                        },
                        new
                        {
                            Id = 2,
                            Color = "Blue",
                            Height = 200,
                            ProductId = 2,
                            Width = 500
                        });
                });

            modelBuilder.Entity("KPSS.Core.Product", b =>
                {
                    b.HasOne("KPSS.Core.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("KPSS.Core.ProductFeature", b =>
                {
                    b.HasOne("KPSS.Core.Product", "Product")
                        .WithOne("ProductFeature")
                        .HasForeignKey("KPSS.Core.ProductFeature", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KPSS.Core.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("KPSS.Core.Product", b =>
                {
                    b.Navigation("ProductFeature");
                });
#pragma warning restore 612, 618
        }
    }
}
