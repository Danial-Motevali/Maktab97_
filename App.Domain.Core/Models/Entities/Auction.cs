using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Auction
{
    public int? Id { get; set; }

    public int? LastPrice { get; set; }

    public int? ParentId { get; set; } 

    public Auction? Parent { get; set; }

    public bool IsActive { get; set; } = true;

    public int? SellerId { get; set; }

    public Seller? Seller { get; set; } 

    public int? UserId { get; set; }

    public User? User { get; set; }

    public int? WinnerId { get; set; }

    public User? Winner { get; set; }

    public DateTime? TimeOfStart { get; set; }

    public DateTime? TimeOfEnd { get; set; }

    public ICollection<Inventory>? Inventories { get; set; }
}
