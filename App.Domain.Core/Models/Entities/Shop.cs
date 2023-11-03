namespace App.Domain.Core.Entities;

public class Shop
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime TimeOfCreate { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public Seller? Seller { get; set; }
}
