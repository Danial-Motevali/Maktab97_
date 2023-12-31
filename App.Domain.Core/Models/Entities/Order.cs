﻿using App.Domain.Core.Entities;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int? BuyerId { get; set; }

        public Buyer? Buyer { get; set; } 

        public bool IsDeleted { get; set; } = false;

        public ICollection<InventoryOreder>? inventoryOreders { get; set; } 

    }
}
