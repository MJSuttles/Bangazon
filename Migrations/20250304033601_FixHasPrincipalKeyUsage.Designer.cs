﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    [Migration("20250304033601_FixHasPrincipalKeyUsage")]
    partial class FixHasPrincipalKeyUsage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bangazon.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserPaymentMethodId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Bangazon.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CartId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<int>("UserPaymentMethodId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserPaymentMethodId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Bangazon.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrdersItems");
                });

            modelBuilder.Entity("Bangazon.Models.PaymentOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentOptions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Credit Card"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Apple Pay"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Google Pay"
                        },
                        new
                        {
                            Id = 4,
                            Type = "PayPal"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("SellerId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Bangazon.Models.User", b =>
                {
                    b.Property<string>("Uid")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Uid");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Uid = "BCyBV6WJpTZcPG0b0WMfr8vJM1B3",
                            Address = "123 Elm Street",
                            City = "Nashville",
                            Email = "rolltiderolldad@gmail.com",
                            FirstName = "Brian",
                            LastName = "Suttles",
                            State = "TN",
                            Zip = "37201"
                        },
                        new
                        {
                            Uid = "LoBA4EB98KfPtTZ7t8hE2xlbURw1",
                            Address = "123 Elm Street",
                            City = "Nashville",
                            Email = "suttles95@gmail.com",
                            FirstName = "Dayna",
                            LastName = "Suttles",
                            State = "TN",
                            Zip = "37201"
                        },
                        new
                        {
                            Uid = "9a53d726-a2cd-42df-9d0f-5ae1a45c1c75",
                            Address = "789 Pine Street",
                            City = "Atlanta",
                            Email = "alicej@example.com",
                            FirstName = "Alice",
                            LastName = "Johnson",
                            State = "GA",
                            Zip = "30301"
                        },
                        new
                        {
                            Uid = "fa80e4a1-53b7-4784-ab59-6574dea65bb0",
                            Address = "321 Maple Avenue",
                            City = "Charlotte",
                            Email = "bobb@example.com",
                            FirstName = "Bob",
                            LastName = "Brown",
                            State = "NC",
                            Zip = "28202"
                        },
                        new
                        {
                            Uid = "2fe66f47-afdb-4a83-9dff-2d8e60b51b7a",
                            Address = "654 Cedar Road",
                            City = "Louisville",
                            Email = "charliem@example.com",
                            FirstName = "Charlie",
                            LastName = "Miller",
                            State = "KY",
                            Zip = "40202"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.UserPaymentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PaymentOptionId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PaymentOptionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPaymentMethods");
                });

            modelBuilder.Entity("Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Vinyl"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Cassette"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Compact Disc"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Cart", b =>
                {
                    b.HasOne("Bangazon.Models.User", "User")
                        .WithOne()
                        .HasForeignKey("Bangazon.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bangazon.Models.CartItem", b =>
                {
                    b.HasOne("Bangazon.Models.Cart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.Product", "Product")
                        .WithOne("CartItem")
                        .HasForeignKey("Bangazon.Models.CartItem", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.HasOne("Bangazon.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.UserPaymentMethod", "UserPaymentMethod")
                        .WithMany()
                        .HasForeignKey("UserPaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserPaymentMethod");
                });

            modelBuilder.Entity("Bangazon.Models.OrderItem", b =>
                {
                    b.HasOne("Bangazon.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.HasOne("Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bangazon.Models.UserPaymentMethod", b =>
                {
                    b.HasOne("Bangazon.Models.PaymentOption", "PaymentOption")
                        .WithMany("UserPaymentMethods")
                        .HasForeignKey("PaymentOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.User", "User")
                        .WithMany("UserPaymentMethods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentOption");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bangazon.Models.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Bangazon.Models.PaymentOption", b =>
                {
                    b.Navigation("UserPaymentMethods");
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Navigation("CartItem")
                        .IsRequired();

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Bangazon.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserPaymentMethods");
                });

            modelBuilder.Entity("Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
