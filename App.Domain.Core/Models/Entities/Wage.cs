using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Wage
{
    public int Id { get; set; }

    public int HowMuch { get; set; }

    public bool IsDeleted { get; set; } = false;

    public bool IsPaid { get; set; } = false;

    public int? InventoryId { get; set; }

    public Inventory? Inventory { get; set; }

    public int? SellerId { get; set; }

    public Seller? User { get; set; } 
}
