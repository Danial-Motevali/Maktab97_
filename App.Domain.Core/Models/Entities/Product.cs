﻿using App.Domain.Core.Models.Entities;

namespace App.Domain.Core.Entities;

public class Product
{
    public int Id { get; set; }

    public string? Title { get; set; } = null!;

    public bool IsDeleted { get; set; } = false;

    public int? CategoryId { get; set; }

    public Category? Category { get; set; }

    public ICollection<Inventory>? Inventories { get; set; } 

    public ICollection<ProductPicture>? ProductPictures { get; set; } 

}
