using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Cart
{
    public int Id { get; set; }

    public bool? IsActive { get; set; } = true;

    public DateTime? TimeOfCreate { get; set; }

    public int? BuyerId { get; set; }

    public Buyer? Buyer { get; set; }

    public int? InventoryId { get; set; }

    public Inventory? Inventory { get; set; }

    public bool IsDeleted { get; set; } = false;
}
