using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class InventoryOreder
    {
        public int Id { get; set; }

        public int? OrederId { get; set; }  

        public Order? Order { get; set; } 

        public int? InventoryId { get; set; }

        public Inventory? Inventory { get; set; } 

        public bool IsDeleted { get; set; } = false;
    }
}
