﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TWYLisans.Persistence.Context;

#nullable disable

namespace TWYLisans.Persistence.Migrations
{
    [DbContext(typeof(TWYLisansDbContext))]
    [Migration("20230725133358_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TWYLisans.Domain.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            categoryName = "A kategorisi"
                        },
                        new
                        {
                            ID = 2,
                            categoryName = "B kategorisi"
                        });
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("cityname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Citys");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            cityname = "Ankara"
                        },
                        new
                        {
                            ID = 2,
                            cityname = "Bursa"
                        });
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ePosta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("mailaddress")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("phoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("townId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("townId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            active = true,
                            companyName = "A şirketi",
                            ePosta = "aaa@aaa.aaa",
                            mailaddress = new byte[] { 109, 97, 105, 108, 97, 100, 114, 101, 115, 115, 49 },
                            phoneNumber = "00220202101",
                            townId = 1
                        },
                        new
                        {
                            ID = 2,
                            active = true,
                            companyName = "B şirketi",
                            ePosta = "bbb@bbb.bbb",
                            mailaddress = new byte[] { 109, 97, 105, 108, 97, 100, 114, 101, 115, 115, 50 },
                            phoneNumber = "22202020202",
                            townId = 2
                        },
                        new
                        {
                            ID = 3,
                            active = true,
                            companyName = "C şirketi",
                            ePosta = "ccc@ccc.ccc",
                            mailaddress = new byte[] { 109, 97, 105, 108, 97, 100, 114, 101, 115, 115, 51 },
                            phoneNumber = "30303030303",
                            townId = 3
                        });
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Licence", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("endingDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("licencekey")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("customerId");

                    b.HasIndex("productId");

                    b.ToTable("Licences");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            active = true,
                            creationDate = new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3316),
                            customerId = 1,
                            endingDate = new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3328),
                            licencekey = new Guid("8b6797d6-dddf-4acc-8478-f6078996cb6d"),
                            productId = 1
                        },
                        new
                        {
                            ID = 2,
                            active = true,
                            creationDate = new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3331),
                            customerId = 2,
                            endingDate = new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3332),
                            licencekey = new Guid("378ccfc5-a090-4fb1-b74d-6dbeb9446ab4"),
                            productId = 2
                        },
                        new
                        {
                            ID = 3,
                            active = true,
                            creationDate = new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3333),
                            customerId = 2,
                            endingDate = new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3334),
                            licencekey = new Guid("31686c71-dc82-4361-8c2e-ce5a3afe7206"),
                            productId = 1
                        },
                        new
                        {
                            ID = 4,
                            active = true,
                            creationDate = new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3335),
                            customerId = 3,
                            endingDate = new DateTime(2023, 7, 25, 16, 33, 57, 996, DateTimeKind.Local).AddTicks(3335),
                            licencekey = new Guid("484feabb-6c8c-424c-a2c3-8a3162fce583"),
                            productId = 2
                        });
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("active")
                        .HasColumnType("bit");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("productDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("categoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            active = true,
                            categoryId = 1,
                            productDescription = "A açıklaması",
                            productName = "A Ürünü"
                        },
                        new
                        {
                            ID = 2,
                            active = true,
                            categoryId = 2,
                            productDescription = "B açıklaması",
                            productName = "B Ürünü"
                        });
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Town", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("cityId")
                        .HasColumnType("int");

                    b.Property<string>("townname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("cityId");

                    b.ToTable("Towns");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            cityId = 1,
                            townname = "Çankaya"
                        },
                        new
                        {
                            ID = 2,
                            cityId = 1,
                            townname = "Haymana"
                        },
                        new
                        {
                            ID = 3,
                            cityId = 2,
                            townname = "Nilüfer"
                        });
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Customer", b =>
                {
                    b.HasOne("TWYLisans.Domain.Entities.Town", "town")
                        .WithMany("customers")
                        .HasForeignKey("townId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("town");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Licence", b =>
                {
                    b.HasOne("TWYLisans.Domain.Entities.Customer", "customer")
                        .WithMany("licences")
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TWYLisans.Domain.Entities.Product", "product")
                        .WithMany("licences")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("customer");

                    b.Navigation("product");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Product", b =>
                {
                    b.HasOne("TWYLisans.Domain.Entities.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Town", b =>
                {
                    b.HasOne("TWYLisans.Domain.Entities.City", "city")
                        .WithMany("towns")
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.City", b =>
                {
                    b.Navigation("towns");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Customer", b =>
                {
                    b.Navigation("licences");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Product", b =>
                {
                    b.Navigation("licences");
                });

            modelBuilder.Entity("TWYLisans.Domain.Entities.Town", b =>
                {
                    b.Navigation("customers");
                });
#pragma warning restore 612, 618
        }
    }
}