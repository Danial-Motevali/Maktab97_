using App.Domain.Core.Entities;
using App.Domain.Core.Models.Identity.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data.EF;   

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Buyer> Buyers { get; set; }

    public DbSet<MyAdmin> Admins { get; set; }

    public DbSet<Seller> Sellers { get; set; }

    public  DbSet<Address> Addresses { get; set; }

    public  DbSet<Auction> Auctions { get; set; }

    public  DbSet<Cart> Carts { get; set; }

    public  DbSet<Category> Categories { get; set; }

    public  DbSet<Comment> Comments { get; set; }

    public  DbSet<Inventory> Inventories { get; set; }

    public  DbSet<Medal> Medals { get; set; }

    public  DbSet<Picture> Pictures { get; set; }

    public  DbSet<Price> Prices { get; set; }

    public  DbSet<Product> Products { get; set; }

    public  DbSet<ProductPicture> ProductPictures { get; set; }

    public  DbSet<Shop> Shops { get; set; }

    public  DbSet<Wage> Wages { get; set; }

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

            //entity.HasData(
            //    new Address { Id = 1, City = "Tehran", Street = "abasabad", IsDeleted = false, MyAdminId = 1, },
            //    new Address { Id = 2, City = "Mashhad", Street = "farahani", IsDeleted = false, SellerId = 1, },
            //    new Address { Id = 3, City = "Esfahan", Street = "milad", IsDeleted = false, BuyerId = 1, }
            //    ) ;
        });

        modelBuilder.Entity<MyAdmin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.Id).ValueGeneratedNever();

        });

        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.ToTable("Buyer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Buyer).WithOne(p => p.Cart)
                .HasForeignKey<Cart>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //entity.HasData(
            //    new Cart { Id = 1, IsActive = true, TimeOfCreate =  DateTime.UtcNow, BuyerId = 1 },
            //    new Cart { Id = 2, IsActive = false, TimeOfCreate =  DateTime.UtcNow, BuyerId = 2 }
            //    );
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.product).WithOne(p => p.Category)
                .HasForeignKey<Category>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //entity.HasData(
            //    new Category { Id = 1, IsDeleted = true, ParentId = 0, Title = "electronic" },
            //    new Category { Id = 2, IsDeleted = true, ParentId = 1, Title = "Phone" });
        });

        modelBuilder.Entity<Comment>(entity =>
        {
        entity.HasOne(d => d.Buyer).WithMany(p => p.Comments)
            .HasForeignKey(d => d.BuyerId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.Inventory).WithMany(p => p.Comments)
            .HasForeignKey(d => d.InventoryId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        //entity.HasData(
        //    new Comment { Id = 1, Title = "GoodStofe", Description = "I realy like this product", TimeOfCreate = DateTime.Now, BuyerId = 1, IsDeleted = false },
        //    new Comment { Id = 2, Title = "Bad stofe", Description = "I Dont like this", TimeOfCreate = DateTime.Now, BuyerId = 3, IsDeleted = true });
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.ToTable("Inventory");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Auction).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Cart).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.CartId)
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

            //entity.HasData(
            //    new Inventory { Id = 1, Qnt = 3, IsDeleted =  false, CartId = 1, PriceId = 1, ShopId = 1, AuctionId = 1 , ProductId = 1},
            //    new Inventory { Id = 2, Qnt = 1, IsDeleted =  true, CartId = 2, PriceId = 1, ShopId = 2, AuctionId = 1, ProductId = 1 }
            //    );
        });

        modelBuilder.Entity<Medal>(entity =>
        {
            entity.ToTable("Medal");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Rank)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Seller).WithMany(p => p.Medals)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            //entity.HasData(
            //    new Medal { Id = 1, Rank = "Coper", SellerId = 1 },
            //    new Medal { Id = 2, Rank = "Silver", SellerId = 1 }
            //    );
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Picture");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            //entity.HasData(
            //    new Product { Id = 1, CategoryId = 2, IsDeleted = true, Title= "Book"},
            //    new Product { Id = 2, CategoryId = 2, IsDeleted = true, Title= "rzazi"}
            //    );
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

            entity.HasOne(d => d.Shop).WithOne(p => p.Seller)
                .HasForeignKey<Seller>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seller_Auctions");

            entity.HasOne(d => d.Auction).WithOne(p => p.Seller)
                .HasForeignKey<Seller>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seller_Shops");
        });

        modelBuilder.Entity<Wage>(entity =>
        {
            entity.HasOne(d => d.User).WithMany(p => p.Wages)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Wages_Seller");

            //entity.HasData(
            //    new Wage { Id = 1, HowMuch = 200, IsDeleted = true, SellerId = 1 },
            //    new Wage { Id = 2, HowMuch = 300, IsDeleted = false, SellerId = 2 }
            //    );
        });

        base.OnModelCreating(modelBuilder);

        //    OnModelCreatingPartial(modelBuilder);
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
