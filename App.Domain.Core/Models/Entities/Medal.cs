namespace App.Domain.Core.Entities;

public class Medal
{
    public int Id { get; set; }

    public string Rank { get; set; } = null!;

    public int UserId { get; set; }

    public Seller User { get; set; } = null!;
}
