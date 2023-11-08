namespace App.Domain.Core.Entities;

public class Category
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ParentId { get; set; }
    public Category? Parent { get; set; }

    public bool IsDeleted { get; set; }

    public int? ProductId { get; set; }
    public Product product { get; set; } = null!;
}
