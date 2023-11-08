﻿using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Cart
{
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public DateTime TimeOfCreate { get; set; }

    public int? BuyerId { get; set; }
    public Buyer? Buyer { get; set; } 

    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
