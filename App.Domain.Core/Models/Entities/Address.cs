using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Address
{
    public int Id { get; set; }

    public string? City { get; set; } 

    public string? Street { get; set; } 

    public bool IsDeleted { get; set; } = false;


    public int? MyAdminId { get; set; }
    public  MyAdmin? MyAdmin { get; set; }

    public int? SellerId { get; set; }
    public  Seller? Seller { get; set; }

    public int? BuyerId { get; set; }
    public  Buyer? Buyer { get; set; } 
}
