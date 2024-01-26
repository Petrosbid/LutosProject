﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Context;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(LutosContext))]
    partial class LutosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Models.Myproducts", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"), 1L, 1);

                    b.Property<bool?>("Available")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("bit");

                    b.Property<string>("Category")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Liked")
                        .HasColumnType("int");

                    b.Property<string>("Main_Image")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("MyUsersId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProductPrice")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("Slider")
                        .HasColumnType("bit");

                    b.HasKey("ProductID");

                    b.HasIndex("MyUsersId");

                    b.ToTable("Products_Info", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.MyUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("LastName")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("PostalCode")
                        .HasMaxLength(15)
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Users_Info", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.ProductComments", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentID"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("MyproductsProductID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("CommentID");

                    b.HasIndex("MyproductsProductID");

                    b.ToTable("Product_Comments", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.Myproducts", b =>
                {
                    b.HasOne("WebApplication1.Models.MyUsers", null)
                        .WithMany("CartProducts")
                        .HasForeignKey("MyUsersId");
                });

            modelBuilder.Entity("WebApplication1.Models.ProductComments", b =>
                {
                    b.HasOne("WebApplication1.Models.Myproducts", null)
                        .WithMany("ProductComments")
                        .HasForeignKey("MyproductsProductID");
                });

            modelBuilder.Entity("WebApplication1.Models.Myproducts", b =>
                {
                    b.Navigation("ProductComments");
                });

            modelBuilder.Entity("WebApplication1.Models.MyUsers", b =>
                {
                    b.Navigation("CartProducts");
                });
#pragma warning restore 612, 618
        }
    }
}