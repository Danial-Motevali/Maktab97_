namespace App.Domain.Core.Entities;

public class Inventory
{
    public int Id { get; set; }
    public int Qnt { get; set; }
    public bool IsDeleted { get; set; }

    public int? AuctionId { get; set; }
    public Auction Auction { get; set; } = null!;

    public int? CartId { get; set; }

    public Cart Cart { get; set; } = null!;

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public int? PriceId { get; set; }

    public Price Price { get; set; } = null!;

    public int? ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int? ShopId { get; set; }

    public Shop Shop { get; set; } = null!;
}
