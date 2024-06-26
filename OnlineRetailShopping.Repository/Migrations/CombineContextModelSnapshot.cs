﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineRetailShopping.Repository;

#nullable disable

namespace OnlineRetailShopping.Repository.Migrations
{
    [DbContext(typeof(CombineContext))]
    partial class CombineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineRetailShopping.Repository.Entities.Customer", b =>
                {
                    b.Property<Guid>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("customerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("emailID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mobile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("customerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("OnlineRetailShopping.Repository.Entities.Order", b =>
                {
                    b.Property<Guid>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCancel")
                        .HasColumnType("bit");

                    b.Property<Guid>("customerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("productId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("orderId");

                    b.HasIndex("customerId");

                    b.HasIndex("productId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("OnlineRetailShopping.Repository.Entities.Product", b =>
                {
                    b.Property<Guid>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("productId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("OnlineRetailShopping.Repository.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnlineRetailShopping.Repository.Entities.Order", b =>
                {
                    b.HasOne("OnlineRetailShopping.Repository.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineRetailShopping.Repository.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
