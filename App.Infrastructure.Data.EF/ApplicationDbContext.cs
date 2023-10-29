using App.Domain.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Data.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions optios) : base(optios)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Pictoure> Pictoures { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Wage> Wages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Shop)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ShopId);

            modelBuilder.Entity<Address>()
                .HasOne(x => x.Profile)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.ProfileId);

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.Profile)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.ProfileId);


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
