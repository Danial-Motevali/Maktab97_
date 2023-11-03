namespace App.Domain.Core.Entities;

public class Cart
{
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public DateTime TimeOfCreate { get; set; }

    public Buyer IdNavigation { get; set; } = null!;

    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
