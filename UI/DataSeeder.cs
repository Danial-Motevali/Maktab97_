using App.Domain.Core.Entities;
using App.Domain.Core.Models.Entities;
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
            //entity with no fo key
            if (!dbContext.Users.Any())
            {
                var Address = new List<User>
                {
                    new User {FirstName = "Danial", LastName = "Motevali", UserName = "Danial",NormalizedUserName ="DANIAL", ConcurrencyStamp = "9918ccd6-5bc5-4bac-b9d4-79e07f5cc5f9" ,SecurityStamp = "O5CTDXNJGL245D4SJJL6WVDQANKXF53Z", Email = "danial.motevali.82@gmail.com", IsDeleted = false, PasswordHash = "AQAAAAIAAYagAAAAEJgL3NT21uZb72NE7HpS3Y4Tk1QN3OnrzidYKp53nxeHw/ThvSSV+5rUygVnuFMQJw==", EmailConfirmed = true, Potion = Potion.Owner},
                    new User { FirstName = "First", LastName = "Admin", UserName = "Admin1", NormalizedUserName = "ADMIN1", ConcurrencyStamp = "cb18c385-0c69-424d-88ca-df29d472a8df", SecurityStamp = "H4QM3I6HXNSZVBQNRTV6WRFXUZCCJOJD", Email = "admin1@gmail.com", IsDeleted = false, PasswordHash = "AQAAAAIAAYagAAAAEJgL3NT21uZb72NE7HpS3Y4Tk1QN3OnrzidYKp53nxeHw/ThvSSV+5rUygVnuFMQJw==", EmailConfirmed = true, Potion = Potion.Admin},
                    new User { FirstName = "First", LastName = "Buyer", UserName = "Buyer1", NormalizedUserName = "BUYER1", ConcurrencyStamp = "bb9faf73-5132-43a6-9efa-860b4102d994", SecurityStamp = "WF6MJR3F4C7ILHY2XYEGEP426XCHDNVQ", Email = "buyer1@gmail.com", IsDeleted = false, PasswordHash = "AQAAAAIAAYagAAAAEJgL3NT21uZb72NE7HpS3Y4Tk1QN3OnrzidYKp53nxeHw/ThvSSV+5rUygVnuFMQJw==", EmailConfirmed = true, Potion = Potion.Buyer},
                    new User { FirstName = "First", LastName = "Seller", UserName = "Seller1", NormalizedUserName = "SELLER1", ConcurrencyStamp = "d817253d-5b89-4f6e-bb00-b650dcfd4d0e", SecurityStamp = "3U7NMA6XIJOBG5B3RZ3353IIVFIBRBBM", Email = "seller1@gmail.com", IsDeleted = false, PasswordHash = "AQAAAAIAAYagAAAAEJgL3NT21uZb72NE7HpS3Y4Tk1QN3OnrzidYKp53nxeHw/ThvSSV+5rUygVnuFMQJw==", EmailConfirmed = true, Potion = Potion.Seller}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            //if (!dbContext.Pictures.Any())
            //{
            //    var Address = new List<Picture>
            //    {
            //        new Picture { IsDeleted = false, Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRK14YBkX2xiGRyEnptOiRHjxE9nd8Qr2iYDbHFbXKdgg&s" }
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.Categories.Any())
            //{
            //    var Address = new List<Category>
            //    {
            //        new Category {Title = "electranic", IsDeleted = false},
            //        new Category {Title = "Phone", ParentId = 1, IsDeleted = false}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            if (!dbContext.IdRoles.Any()) 
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
            }

            //if (!dbContext.Prices.Any())
            //{
            //    var Address = new List<Price>
            //    {
            //        new Price { ProdutPrice = 200, IsDeleted = true}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}









            //entity with fo key
            if (!dbContext.Sellers.Any())
            {
                var Address = new List<Seller>
                {
                    new Seller {UserId = 4}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }
            
            if (!dbContext.UserRoles.Any())
            {
                var Address = new List<IdentityUserRole<int>>
                    {
                        new IdentityUserRole<int> { UserId = 1, RoleId = 1},
                        new IdentityUserRole<int> { UserId = 1, RoleId = 2},
                        new IdentityUserRole<int> { UserId = 2, RoleId = 2},
                        new IdentityUserRole<int> { UserId = 3, RoleId = 4},
                        new IdentityUserRole<int> { UserId = 4, RoleId = 3}
                    };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            //if (!dbContext.Auctions.Any())
            //{
            //    var Address = new List<Auction>
            //    {
            //        new Auction { LastPrice = 100, TimeOfStart = DateTime.Now, TimeOfEnd = DateTime.UtcNow, IsActive = false, SellerId = 1}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

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

            if (!dbContext.Buyers.Any())
            {
                var Address = new List<Buyer>
                {
                    new Buyer { UserId = 3}
                };

                dbContext.AddRange(Address);
                dbContext.SaveChanges();
            }

            //if (!dbContext.Products.Any())
            //{
            //    var Address = new List<Product>
            //    {
            //        new Product { Title = "IPhone", IsDeleted = false, CategoryId = 2}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.orders.Any())
            //{
            //    var Address = new List<Order>
            //    {
            //        new Order { BuyerId = 1, IsDeleted = false}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.productOreders.Any())
            //{
            //    var Address = new List<ProductOreder>
            //    {
            //        new ProductOreder { OrederId = 1, ProductId = 1, IsDeleted = false}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.Shops.Any())
            //{
            //    var Address = new List<Shop>
            //    {
            //        new Shop { Name = "phoneshop!!!", TimeOfCreate = DateTime.Now, IsDeleted = false, SellerId = 1}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.Inventories.Any())
            //{
            //    var Address = new List<Inventory>
            //    {
            //        new Inventory { Qnt = 3, IsDeleted = false, PriceId = 1, ProductId = 1, ShopId = 1}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.Carts.Any())
            //{
            //    var Address = new List<Cart>
            //    {
            //        new Cart { TimeOfCreate = DateTime.Now, IsActive = true, BuyerId = 1, InventoryId = 1}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.Comments.Any())
            //{
            //    var Address = new List<Comment>
            //    {
            //        new Comment { Title = "Goodstafe", Description = "this is the good produt", IsDeleted = false, TimeOfCreate = DateTime.Now, BuyerId = 1, /*InventoryId = 1*/},
            //        new Comment { Title = "Badproduct", Description = "this product is bad for you", IsDeleted = false, TimeOfCreate = DateTime.Now, BuyerId = 1, /*InventoryId = 1*/}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.Medals.Any())
            //{
            //    var Address = new List<Medal>
            //    {
            //        new Medal { Rank = "Coper", SellerId = 1, IsExpired = true},
            //        new Medal { Rank = "Silver", SellerId = 1, IsExpired = false}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.Wages.Any())
            //{
            //    var Address = new List<Wage>
            //    {
            //        new Wage { HowMuch = 10, IsDeleted = false, SellerId = 1, InventoryId = 1, IsPaid = false}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.ProductPictures.Any())
            //{
            //    var Address = new List<ProductPicture>
            //    {
            //        new ProductPicture { PictureId = 1, ProductId = 1}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.orders.Any())
            //{
            //    var Address = new List<Order>
            //    {
            //        new Order{ IsDeleted = false, BuyerId = 1}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}

            //if (!dbContext.productOreders.Any())
            //{
            //    var Address = new List<ProductOreder>
            //    {
            //        new ProductOreder{ IsDeleted = false, OrederId = 1, ProductId = 1}
            //    };

            //    dbContext.AddRange(Address);
            //    dbContext.SaveChanges();
            //}
        }
    }
}
