using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Address
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public bool IsDeleted { get; set; }


    public int? MyAdminId { get; set; }
    public  MyAdmin? MyAdmin { get; set; }

    public int? SellerId { get; set; }
    public  Seller? Seller { get; set; }

    public int? BuyerId { get; set; }
    public  Buyer? Buyer { get; set; } 
}
