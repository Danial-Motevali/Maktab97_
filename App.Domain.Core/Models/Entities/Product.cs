using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Qty { get; set; }
        public bool IsDeleted { get; set; }

        public int PictureId { get; set; }
        public Pictoure Pictoure { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool HasPrice { get; set; }
        public int PriceId { get; set; }
        public Price Price { get; set; }

        public int AuctionId { get; set; }
        public Auction Auction { get; set; }

        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}
