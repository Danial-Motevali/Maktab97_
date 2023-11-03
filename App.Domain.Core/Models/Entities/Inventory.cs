namespace App.Domain.Core.Entities;

public class Inventory
{
    public int Id { get; set; }

    public int ShopId { get; set; }

    public int ProductId { get; set; }

    public int PriceId { get; set; }

    public int Qnt { get; set; }

    public int AuctionId { get; set; }

    public int CartId { get; set; }

    public bool IsDeleted { get; set; }

    public Auction Auction { get; set; } = null!;

    public Cart Cart { get; set; } = null!;

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public Price Price { get; set; } = null!;

    public Product Product { get; set; } = null!;

    public Shop Shop { get; set; } = null!;
}
