﻿using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Auction
{
    public int? Id { get; set; }

    public int? LastPrice { get; set; }

    public bool IsActive { get; set; } = true;

    public int? SellerId { get; set; }
    public Seller? Seller { get; set; } 

    public DateTime? TimeOfStart { get; set; }

    public DateTime? TimeOfEnd { get; set; }

    public ICollection<Inventory>? Inventories { get; set; }
}
