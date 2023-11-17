using App.Domain.Core.Entities;
using App.Domain.Core.Models.Identity.Entites;
using App.Infrastructure.Data.EF;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UI
{
    public class DataSeeder
    {
        public static void Seedfordata(ApplicationDbContext dbContext) 
        {
            if (!dbContext.Categories.Any())
            {
                var Address = new List<Category>
                {
                    new Category {Title = "electranic", IsDeleted = false},
                    new Category {Title = "Phone", ParentId = 1, IsDeleted = false}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            } //0

            if (!dbContext.Users.Any()) //0
            {
                var Address = new List<User>
                {
                    new User {FirstName = "Danial", LastName = "Motevali", UserName = "Danial", Email = "danial.motevali.82@gmail.com", IsDeleted = false, PasswordHash = "AQAAAAIAAYagAAAAEJgL3NT21uZb72NE7HpS3Y4Tk1QN3OnrzidYKp53nxeHw/ThvSSV+5rUygVnuFMQJw=="},
                    new User { FirstName = "First", LastName = "Admin", UserName = "Admin1", Email = "admin1@gmail.com", IsDeleted = false, PasswordHash = "AQAAAAIAAYagAAAAEJgL3NT21uZb72NE7HpS3Y4Tk1QN3OnrzidYKp53nxeHw/ThvSSV+5rUygVnuFMQJw=="},
                    new User { FirstName = "First", LastName = "Buyer", UserName = "Buyer1", Email = "buyer1@gmail.com", IsDeleted = false, PasswordHash = "AQAAAAIAAYagAAAAEJgL3NT21uZb72NE7HpS3Y4Tk1QN3OnrzidYKp53nxeHw/ThvSSV+5rUygVnuFMQJw=="},
                    new User { FirstName = "First", LastName = "Seller", UserName = "Seller1", Email = "seller1@gmail.com", IsDeleted = false, PasswordHash = "AQAAAAIAAYagAAAAEJgL3NT21uZb72NE7HpS3Y4Tk1QN3OnrzidYKp53nxeHw/ThvSSV+5rUygVnuFMQJw=="}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            } //0

            if (!dbContext.IdRoles.Any()) //0
            {
                var Address = new List<IdentityRole<int>>
                {
                    new IdentityRole<int> { Name="Owner", NormalizedName = "OWNER"},
                    new IdentityRole<int> { Name="Admin", NormalizedName = "ADMIN"},
                    new IdentityRole<int> { Name="Seller", NormalizedName = "SELLER"},
                    new IdentityRole<int> { Name="Buyer", NormalizedName = "BUYER"}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            } //0

            if (!dbContext.UserRoles.Any()) 
            {
                var Address = new List<IdentityUserRole<int>>
                {
                    new IdentityUserRole<int> { UserId = 1, RoleId = 1},
                    new IdentityUserRole<int> { UserId = 2, RoleId = 2},
                    new IdentityUserRole<int> { UserId = 3, RoleId = 4},
                    new IdentityUserRole<int> { UserId = 4, RoleId = 3}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            } 

            if (!dbContext.Carts.Any()) //0
            {
                var Address = new List<Cart>
                {
                    new Cart { TimeOfCreate = DateTime.Now, IsActive = true}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            } //0

            if (!dbContext.Auctions.Any())
            {
                var Address = new List<Auction>
                {
                    new Auction { LastPrice = 100, TimeOfStart = DateTime.Now, TimeOfEnd = DateTime.UtcNow, IsActive = false}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            } //0

            if (!dbContext.MyAdmins.Any())
            {
                var Address = new List<MyAdmin>
                {
                    new MyAdmin { UserId = 1},
                    new MyAdmin { UserId = 2}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            if (!dbContext.Carts.Any())
            {
                var Address = new List<Cart>
                {
                    new Cart { TimeOfCreate = DateTime.Now, IsActive = true}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            } //0

            if (!dbContext.Buyers.Any())
            {
                var Address = new List<Buyer>
                {
                    new Buyer { UserId = 3, CartId = 1}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            if (!dbContext.Sellers.Any())
            {
                var Address = new List<Seller>
                {
                    new Seller { AuctionId = 1, UserId = 4}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            if (!dbContext.Prices.Any())
            {
                var Address = new List<Price>
                {
                    new Price { ProdutPrice = 200, IsDeleted = true}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            } // 0

            if (!dbContext.Products.Any())
            {
                var Address = new List<Product>
                {
                    new Product { Title = "Phone", IsDeleted = false, CategoryId = 2}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            if (!dbContext.Shops.Any())
            {
                var Address = new List<Shop>
                {
                    new Shop { Name = "phoneshop!!!", TimeOfCreate = DateTime.Now, IsDeleted = false, SellerId = 1}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            if (!dbContext.Inventories.Any())
            {
                var Address = new List<Inventory>
                {
                    new Inventory { Qnt = 3, IsDeleted = false, CartId = 1, PriceId = 1, ProductId = 1, ShopId = 1}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            if (!dbContext.Comments.Any())
            {
                var Address = new List<Comment>
                {
                    new Comment { Title = "Goodstafe", Description = "this is the good produt", IsDeleted = false, TimeOfCreate = DateTime.Now, BuyerId = 1, InventoryId = 1},
                    new Comment { Title = "Badproduct", Description = "this product is bad for you", IsDeleted = false, TimeOfCreate = DateTime.Now, BuyerId = 1, InventoryId = 1}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            if (!dbContext.Medals.Any())
            {
                var Address = new List<Medal>
                {
                    new Medal { Rank = "Coper", SellerId = 1},
                    new Medal { Rank = "Silver", SellerId = 1}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            if (!dbContext.Wages.Any())
            {
                var Address = new List<Wage>
                {
                    new Wage { HowMuch = 10, IsDeleted = false, SellerId = 1}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            if (!dbContext.Pictures.Any()) // 0
            {
                var Address = new List<Picture>
                {
                    new Picture { IsDeleted = false, Url = "data:image/jpeg;base64,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"}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            if (!dbContext.ProductPictures.Any())
            {
                var Address = new List<ProductPicture>
                {
                    new ProductPicture { PictureId = 1, ProductId = 1}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }
        }
    }
}
