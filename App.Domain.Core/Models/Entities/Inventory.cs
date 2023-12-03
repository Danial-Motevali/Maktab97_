using App.Domain.Core.Models.Entities;

namespace App.Domain.Core.Entities;

public class Inventory
{
    public int Id { get; set; }
    public int? Qnt { get; set; }
    public bool? IsDeleted { get; set; }

    public int? AuctionId { get; set; }
    public Auction? Auction { get; set; } 

    public ICollection<Comment>? Comments { get; set; } 

    public int? PriceId { get; set; }

    public Price? Price { get; set; } 

    public int? ProductId { get; set; }

    public Product? Product { get; set; } 

    public int? ShopId { get; set; }

    public Shop? Shop { get; set; }

    public IEnumerable<InventoryOreder>? inventoryOreders { get; set; }
}
