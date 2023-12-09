using App.Domain.Core.Entities;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto.ControllerDto
{
    public class AuctionHistoryDto
    {
        public int? Id { get; set; }

        public int? LastPrice { get; set; }

        public int? ParentId { get; set; }

        public Auction? Parent { get; set; }

        public bool IsActive { get; set; } = true;

        public int? SellerId { get; set; }

        public Seller? Seller { get; set; }

        public int? UserId { get; set; }

        public User? User { get; set; }

        public DateTime? TimeOfStart { get; set; }

        public DateTime? TimeOfEnd { get; set; }

        public ICollection<Inventory>? Inventories { get; set; }

        public string? BuyerName { get; set; }
    }
}
