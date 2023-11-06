using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Comment
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime TimeOfCreate { get; set; }

    public bool IsDeleted { get; set; }

    public int BuyerId { get; set; }

    public int InventoryId { get; set; }

    public Buyer Buyer { get; set; } = null!;

    public Inventory Inventory { get; set; } = null!;
}
