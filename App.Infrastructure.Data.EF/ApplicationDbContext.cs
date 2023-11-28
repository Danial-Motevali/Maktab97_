using App.Domain.Core.Entities;
using App.Domain.Core.Models.Entities;
using App.Domain.Core.Models.Identity.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data.EF
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }



        public DbSet<Address> Addresses { get; set; }

        public DbSet<Auction> Auctions { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Medal> Medals { get; set; }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductPicture> ProductPictures { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Wage> Wages { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<ProductOreder> productOreders { get; set; }

        //Identity
        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<MyAdmin> MyAdmins { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<IdentityRole<int>> IdRoles { get; set; }

        public DbSet<IdentityUserRole<int>> UserRoles { get;set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(d => d.Buyer).WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Seller).WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.MyAdmin).WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.MyAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(d => d.Buyer).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Inventory).WithMany(p => p.Comments)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.HasOne(d => d.Auction).WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.AuctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Price).WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.PriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Shop).WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Medal>(entity =>
            {
                entity.ToTable("Medal");

                entity.Property(e => e.Rank)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Seller).WithMany(p => p.Medals)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Picture");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");
            });

            modelBuilder.Entity<ProductPicture>(entity =>
            {
                entity.ToTable("ProductPicture");

                entity.HasOne(d => d.Picture).WithMany(p => p.ProductPictures)
                    .HasForeignKey(d => d.PictureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPicture_Picture");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductPictures)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPicture_Products");

            });

            modelBuilder.Entity<Wage>(entity =>
            {
                entity.HasOne(d => d.User).WithMany(p => p.Wages)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wages_Seller");

            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("Seller");

            });

            modelBuilder.Entity<MyAdmin>(entity =>
            {
                entity.ToTable("Admin");


            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("Buyer");

                entity.HasMany(x => x.carts)
                .WithOne(x => x.Buyer)
                .HasForeignKey(x => x.BuyerId);

            });

            modelBuilder.Entity<ProductOreder>(entity =>
            {
                entity.ToTable("ProductOreder");

                entity.HasOne(d => d.Order).WithMany(p => p.productOreders)
                    .HasForeignKey(d => d.OrederId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductOreder_Order");

                entity.HasOne(d => d.Product).WithMany(p => p.productOreders)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductOreder_Products");

            });

            base.OnModelCreating(modelBuilder);

            //    OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
