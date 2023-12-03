﻿// <auto-generated />
using System;
using App.Infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infrastructure.Data.EF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Core.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("MyAdminId")
                        .HasColumnType("int");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("MyAdminId");

                    b.HasIndex("SellerId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Auction", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LastPrice")
                        .HasColumnType("int");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeOfEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TimeOfStart")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("TimeOfCreate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("TimeOfCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuctionId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PriceId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Qnt")
                        .HasColumnType("int");

                    b.Property<int?>("ShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("PriceId");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShopId");

                    b.ToTable("Inventory", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Medal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsExpired")
                        .HasColumnType("bit");

                    b.Property<string>("Rank")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Medal", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Picture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Picture", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("ProdutPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CategoryId" }, "IX_Products_CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.ProductPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PictureId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PictureId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPicture", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeOfCreate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Wage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HowMuch")
                        .HasColumnType("int");

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int?>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.HasIndex("SellerId");

                    b.ToTable("Wages");
                });

            modelBuilder.Entity("App.Domain.Core.Models.Entities.InventoryOreder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("InventoryId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("OrederId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.HasIndex("OrederId");

                    b.ToTable("ProductOreder", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BuyerId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("App.Domain.Core.Models.Identity.Entites.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Buyer", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Models.Identity.Entites.MyAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Models.Identity.Entites.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Seller", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Models.Identity.Entites.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("Potion")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Address", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.Buyer", "Buyer")
                        .WithMany("Addresses")
                        .HasForeignKey("BuyerId");

                    b.HasOne("App.Domain.Core.Models.Identity.Entites.MyAdmin", "MyAdmin")
                        .WithMany("Addresses")
                        .HasForeignKey("MyAdminId");

                    b.HasOne("App.Domain.Core.Models.Identity.Entites.Seller", "Seller")
                        .WithMany("Addresses")
                        .HasForeignKey("SellerId");

                    b.Navigation("Buyer");

                    b.Navigation("MyAdmin");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Auction", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Cart", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.Buyer", "Buyer")
                        .WithMany("carts")
                        .HasForeignKey("BuyerId");

                    b.HasOne("App.Domain.Core.Entities.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.Navigation("Buyer");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Category", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Comment", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.Buyer", "Buyer")
                        .WithMany("Comments")
                        .HasForeignKey("BuyerId");

                    b.HasOne("App.Domain.Core.Entities.Inventory", "Inventory")
                        .WithMany("Comments")
                        .HasForeignKey("InventoryId");

                    b.Navigation("Buyer");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Inventory", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Auction", "Auction")
                        .WithMany("Inventories")
                        .HasForeignKey("AuctionId");

                    b.HasOne("App.Domain.Core.Entities.Price", "Price")
                        .WithMany("Inventories")
                        .HasForeignKey("PriceId");

                    b.HasOne("App.Domain.Core.Entities.Product", "Product")
                        .WithMany("Inventories")
                        .HasForeignKey("ProductId");

                    b.HasOne("App.Domain.Core.Entities.Shop", "Shop")
                        .WithMany("Inventories")
                        .HasForeignKey("ShopId");

                    b.Navigation("Auction");

                    b.Navigation("Price");

                    b.Navigation("Product");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Medal", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.Seller", "Seller")
                        .WithMany("Medals")
                        .HasForeignKey("SellerId");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Product", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.ProductPicture", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Picture", "Picture")
                        .WithMany("ProductPictures")
                        .HasForeignKey("PictureId")
                        .HasConstraintName("FK_ProductPicture_Picture");

                    b.HasOne("App.Domain.Core.Entities.Product", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductPicture_Products");

                    b.Navigation("Picture");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Shop", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Wage", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.HasOne("App.Domain.Core.Models.Identity.Entites.Seller", "User")
                        .WithMany("Wages")
                        .HasForeignKey("SellerId")
                        .HasConstraintName("FK_Wages_Seller");

                    b.Navigation("Inventory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Core.Models.Entities.InventoryOreder", b =>
                {
                    b.HasOne("App.Domain.Core.Entities.Inventory", "Inventory")
                        .WithMany("inventoryOreders")
                        .HasForeignKey("InventoryId")
                        .HasConstraintName("FK_ProductOreder_Products");

                    b.HasOne("App.Domain.Core.Models.Entities.Order", "Order")
                        .WithMany("inventoryOreders")
                        .HasForeignKey("OrederId")
                        .HasConstraintName("FK_ProductOreder_Order");

                    b.Navigation("Inventory");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("App.Domain.Core.Models.Entities.Order", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.Buyer", "Buyer")
                        .WithMany()
                        .HasForeignKey("BuyerId");

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("App.Domain.Core.Models.Identity.Entites.Buyer", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Core.Models.Identity.Entites.MyAdmin", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Core.Models.Identity.Entites.Seller", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.Models.Identity.Entites.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("App.Domain.Core.Models.Identity.Entites.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Auction", b =>
                {
                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Inventory", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("inventoryOreders");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Picture", b =>
                {
                    b.Navigation("ProductPictures");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Price", b =>
                {
                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Product", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("ProductPictures");
                });

            modelBuilder.Entity("App.Domain.Core.Entities.Shop", b =>
                {
                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("App.Domain.Core.Models.Entities.Order", b =>
                {
                    b.Navigation("inventoryOreders");
                });

            modelBuilder.Entity("App.Domain.Core.Models.Identity.Entites.Buyer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Comments");

                    b.Navigation("carts");
                });

            modelBuilder.Entity("App.Domain.Core.Models.Identity.Entites.MyAdmin", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("App.Domain.Core.Models.Identity.Entites.Seller", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Medals");

                    b.Navigation("Wages");
                });
#pragma warning restore 612, 618
        }
    }
}
