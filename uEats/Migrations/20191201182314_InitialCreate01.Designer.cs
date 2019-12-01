﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using uEats.Models;

namespace uEats.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191201182314_InitialCreate01")]
    partial class InitialCreate01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("uEats.Models.Account", b =>
                {
                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AccountUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("uEats.Models.Carrier", b =>
                {
                    b.Property<string>("CarrierId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CarrierAge")
                        .HasColumnType("int");

                    b.Property<float>("CarrierAverageRating")
                        .HasColumnType("real");

                    b.Property<string>("CarrierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarrierStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("CarrierId");

                    b.HasIndex("AccountId");

                    b.HasIndex("LocationId");

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("uEats.Models.Consumer", b =>
                {
                    b.Property<string>("ConsumerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChoiceOfTaste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConsumerAge")
                        .HasColumnType("int");

                    b.Property<string>("ConsumerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.HasKey("ConsumerId");

                    b.HasIndex("AccountId");

                    b.HasIndex("LocationId");

                    b.ToTable("Consumers");
                });

            modelBuilder.Entity("uEats.Models.CustomUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("uEats.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FoodCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("uEats.Models.FoodRestaurant", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AddedIn")
                        .HasColumnType("datetime2");

                    b.Property<float>("FoodRestaurantPrice")
                        .HasColumnType("real");

                    b.HasKey("FoodId", "RestaurantId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("FoodRestaurants");
                });

            modelBuilder.Entity("uEats.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("uEats.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarrierId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConsumerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("FoodRestaurantFoodId")
                        .HasColumnType("int");

                    b.Property<string>("FoodRestaurantRestaurantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<float>("PurchaseAmount")
                        .HasColumnType("real");

                    b.Property<int>("PurchaseRating")
                        .HasColumnType("int");

                    b.HasKey("PurchaseId");

                    b.HasIndex("CarrierId");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("FoodRestaurantFoodId", "FoodRestaurantRestaurantId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("uEats.Models.Restaurant", b =>
                {
                    b.Property<string>("RestaurantId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<float>("RestaurantAverageRating")
                        .HasColumnType("real");

                    b.Property<string>("RestaurantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.HasIndex("AccountId");

                    b.HasIndex("LocationId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("uEats.Models.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("uEats.Models.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("uEats.Models.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("uEats.Models.CustomUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("uEats.Models.Carrier", b =>
                {
                    b.HasOne("uEats.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("uEats.Models.Location", "Location")
                        .WithMany("Carriers")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("uEats.Models.Consumer", b =>
                {
                    b.HasOne("uEats.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("uEats.Models.Location", "Location")
                        .WithMany("Consumers")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("uEats.Models.FoodRestaurant", b =>
                {
                    b.HasOne("uEats.Models.Food", "Food")
                        .WithMany("FoodRestaurants")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("uEats.Models.Restaurant", "Restaurant")
                        .WithMany("FoodRestaurants")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("uEats.Models.Purchase", b =>
                {
                    b.HasOne("uEats.Models.Carrier", "Carrier")
                        .WithMany("Purchases")
                        .HasForeignKey("CarrierId");

                    b.HasOne("uEats.Models.Consumer", "Consumer")
                        .WithMany("Purchases")
                        .HasForeignKey("ConsumerId");

                    b.HasOne("uEats.Models.FoodRestaurant", "FoodRestaurant")
                        .WithMany("Purchases")
                        .HasForeignKey("FoodRestaurantFoodId", "FoodRestaurantRestaurantId");
                });

            modelBuilder.Entity("uEats.Models.Restaurant", b =>
                {
                    b.HasOne("uEats.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("uEats.Models.Location", "Location")
                        .WithMany("Restaurants")
                        .HasForeignKey("LocationId");
                });
#pragma warning restore 612, 618
        }
    }
}
