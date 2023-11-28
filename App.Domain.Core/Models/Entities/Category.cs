namespace App.Domain.Core.Entities;

public class Category
{
    public int Id { get; set; }

    public string? Title { get; set; } 

    public int? ParentId { get; set; }
    public Category? Parent { get; set; }

    public bool? IsDeleted { get; set; }
}
