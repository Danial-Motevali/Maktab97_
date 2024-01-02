using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Medal
{
    public int Id { get; set; }

    public string? Rank { get; set; }

    public bool? IsExpired { get; set; } = false;

    public int? SellerId { get; set; }

    public Seller? Seller { get; set; } 

    public bool IsDeleted { get; set; } = false;

}
