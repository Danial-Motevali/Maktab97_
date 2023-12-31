﻿namespace App.Domain.Core.Entities;

public class Price
{
    public int Id { get; set; }

    public int? ProdutPrice { get; set; }

    public bool IsDeleted { get; set; } = false;

    public ICollection<Inventory>? Inventories { get; set; } 
}
