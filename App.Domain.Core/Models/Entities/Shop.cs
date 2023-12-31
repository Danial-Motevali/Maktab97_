﻿using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Shop
{
    public int Id { get; set; }

    public string? Name { get; set; } = null!;

    public DateTime? TimeOfCreate { get; set; }

    public bool IsDeleted { get; set; } = false;

    public ICollection<Inventory>? Inventories { get; set; }

    public int? SellerId { get; set; }
    public Seller? Seller { get; set; } 
}
