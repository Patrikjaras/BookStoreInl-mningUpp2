﻿// <auto-generated />
using System;
using BookStoreInlämning4.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreInlämning4.Migrations
{
    [DbContext(typeof(BookstoreDbContext))]
    [Migration("20231121125835_inventorybalance")]
    partial class inventorybalance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreInlämning4.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("_Authors");
                });

            modelBuilder.Entity("BookStoreInlämning4.Models.Books", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorIDId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("StoreIDId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorIDId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StoreIDId");

                    b.ToTable("_Books");
                });

            modelBuilder.Entity("BookStoreInlämning4.Models.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("_Categories");
                });

            modelBuilder.Entity("BookStoreInlämning4.Models.InventoryBalance", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InventoryIDId")
                        .HasColumnType("int");

                    b.Property<int?>("StockBalance")
                        .HasColumnType("int");

                    b.Property<int>("StoreIDId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("InventoryIDId");

                    b.HasIndex("StoreIDId");

                    b.ToTable("_InventoryBalance");
                });

            modelBuilder.Entity("BookStoreInlämning4.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("_Stores");
                });

            modelBuilder.Entity("BookStoreInlämning4.Models.Books", b =>
                {
                    b.HasOne("BookStoreInlämning4.Models.Author", "AuthorID")
                        .WithMany()
                        .HasForeignKey("AuthorIDId");

                    b.HasOne("BookStoreInlämning4.Models.Categories", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("BookStoreInlämning4.Models.Store", "StoreID")
                        .WithMany()
                        .HasForeignKey("StoreIDId");

                    b.Navigation("AuthorID");

                    b.Navigation("Category");

                    b.Navigation("StoreID");
                });

            modelBuilder.Entity("BookStoreInlämning4.Models.InventoryBalance", b =>
                {
                    b.HasOne("BookStoreInlämning4.Models.Books", "InventoryID")
                        .WithMany()
                        .HasForeignKey("InventoryIDId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreInlämning4.Models.Store", "StoreID")
                        .WithMany()
                        .HasForeignKey("StoreIDId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InventoryID");

                    b.Navigation("StoreID");
                });
#pragma warning restore 612, 618
        }
    }
}
