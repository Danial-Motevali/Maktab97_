using System;
using System.Collections.Generic;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Identity.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace App.Infrastructure.Data.EF;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Auction> Auctions { get; set; }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Medal> Medals { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductPicture> ProductPictures { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Wage> Wages { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Addresses_Admin");

            entity.HasOne(d => d.UserNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Addresses_Buyer");

            entity.HasOne(d => d.User1).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Addresses_Seller");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsFixedLength();
            entity.Property(e => e.FirsName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PassWord)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.ToTable("Buyer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PassWord)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carts_Buyer");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Category)
                .HasForeignKey<Category>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Categories_Products");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasOne(d => d.Buyer).WithMany(p => p.Comments)
                .HasForeignKey(d => d.BuyerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Buyer");

            entity.HasOne(d => d.Inventory).WithMany(p => p.Comments)
                .HasForeignKey(d => d.InventoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comments_Inventory");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("Inventory");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Auction).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Auctions");

            entity.HasOne(d => d.Cart).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Carts");

            entity.HasOne(d => d.Price).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.PriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Prices");

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Products");

            entity.HasOne(d => d.Shop).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inventory_Shops1");
        });

        modelBuilder.Entity<Medal>(entity =>
        {
            entity.ToTable("Medal");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Rank)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.User).WithMany(p => p.Medals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medal_Seller");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Pictoures");

            entity.ToTable("Picture");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");
        });

        modelBuilder.Entity<ProductPicture>(entity =>
        {
            entity.ToTable("ProductPicture");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Picture).WithMany(p => p.ProductPictures)
                .HasForeignKey(d => d.PictureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductPicture_Picture");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPictures)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductPicture_Products");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.ToTable("Seller");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.LasName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PassWord)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Seller)
                .HasForeignKey<Seller>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seller_Auctions");

            entity.HasOne(d => d.Id1).WithOne(p => p.Seller)
                .HasForeignKey<Seller>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seller_Shops");
        });

        modelBuilder.Entity<Wage>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Wages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wages_Seller");
        });

        base.OnModelCreating(modelBuilder);

        //OnModelCreatingPartial(modelBuilder);
    }

    /*partial void OnModelCreatingPartial(ModelBuilder modelBuilder)*/

}
