﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stores.Data;

#nullable disable

namespace Stores.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20231204230342_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Stores.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Stores.Entities.Employe", b =>
                {
                    b.Property<int>("EmployeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeID"));

                    b.Property<DateTime?>("DateOfWork")
                        .HasColumnType("datetime2");

                    b.Property<int>("HumanID")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreID")
                        .HasColumnType("int");

                    b.HasKey("EmployeID");

                    b.HasIndex("HumanID");

                    b.HasIndex("StoreID");

                    b.ToTable("Employes");
                });

            modelBuilder.Entity("Stores.Entities.Human", b =>
                {
                    b.Property<int>("HumanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HumanID"));

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.HasKey("HumanID");

                    b.ToTable("Humans");
                });

            modelBuilder.Entity("Stores.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<bool>("ExciseNeeded")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMature")
                        .HasColumnType("bit");

                    b.Property<string>("ProductTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SubCategoryID")
                        .HasColumnType("int");

                    b.Property<long>("TaxGroup")
                        .HasColumnType("bigint");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SubCategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Stores.Entities.Store", b =>
                {
                    b.Property<int>("StoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Owner")
                        .HasColumnType("int");

                    b.Property<int>("PostCode")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreID");

                    b.HasIndex("Owner");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Stores.Entities.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategoryID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("SubCategoryTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubCategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Stores.Entities.Employe", b =>
                {
                    b.HasOne("Stores.Entities.Human", "Human")
                        .WithMany()
                        .HasForeignKey("HumanID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Stores.Entities.Store", "Store")
                        .WithMany("Employes")
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Human");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Stores.Entities.Product", b =>
                {
                    b.HasOne("Stores.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Stores.Entities.SubCategory", "SubCategory")
                        .WithMany()
                        .HasForeignKey("SubCategoryID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Stores.Entities.Store", b =>
                {
                    b.HasOne("Stores.Entities.Human", "OwnerHuman")
                        .WithMany()
                        .HasForeignKey("Owner")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("OwnerHuman");
                });

            modelBuilder.Entity("Stores.Entities.SubCategory", b =>
                {
                    b.HasOne("Stores.Entities.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Stores.Entities.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Stores.Entities.Store", b =>
                {
                    b.Navigation("Employes");
                });
#pragma warning restore 612, 618
        }
    }
}