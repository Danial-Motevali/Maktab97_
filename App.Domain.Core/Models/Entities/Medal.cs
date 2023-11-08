using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Medal
{
    public int Id { get; set; }

    public string Rank { get; set; } = null!;

    public int? SellerId { get; set; }

    public Seller Seller { get; set; } = null!;
}
