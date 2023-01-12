﻿// <auto-generated />
using System;
using Eduard_Sergiu.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eduard_Sergiu.Migrations
{
    [DbContext(typeof(Eduard_SergiuContext))]
    partial class Eduard_SergiuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Eduard_Sergiu.Models.Breakfast", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ChefID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,0)");

                    b.Property<int?>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ChefID");

                    b.HasIndex("RestaurantID");

                    b.ToTable("Breakfast");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Chef", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("ChefName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Chef");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.FoodCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("BreakfastID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BreakfastID");

                    b.HasIndex("CategoryID");

                    b.ToTable("FoodCategory");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Reservation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("BreakfastID")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("BreakfastID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Restaurant");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Breakfast", b =>
                {
                    b.HasOne("Eduard_Sergiu.Models.Chef", "Chef")
                        .WithMany("Breakfasts")
                        .HasForeignKey("ChefID");

                    b.HasOne("Eduard_Sergiu.Models.Restaurant", "Restaurant")
                        .WithMany("Breakfasts")
                        .HasForeignKey("RestaurantID");

                    b.Navigation("Chef");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.FoodCategory", b =>
                {
                    b.HasOne("Eduard_Sergiu.Models.Breakfast", "Breakfast")
                        .WithMany("FoodCategories")
                        .HasForeignKey("BreakfastID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eduard_Sergiu.Models.Category", "Category")
                        .WithMany("FoodCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Breakfast");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Reservation", b =>
                {
                    b.HasOne("Eduard_Sergiu.Models.Breakfast", "Breakfast")
                        .WithMany()
                        .HasForeignKey("BreakfastID");

                    b.HasOne("Eduard_Sergiu.Models.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerID");

                    b.Navigation("Breakfast");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Breakfast", b =>
                {
                    b.Navigation("FoodCategories");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Category", b =>
                {
                    b.Navigation("FoodCategories");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Chef", b =>
                {
                    b.Navigation("Breakfasts");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Eduard_Sergiu.Models.Restaurant", b =>
                {
                    b.Navigation("Breakfasts");
                });
#pragma warning restore 612, 618
        }
    }
}
