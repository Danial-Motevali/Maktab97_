using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto.ControllerDto
{
    public class ShopDashBordDto
    {
        public int SellerId { get; set; }
        //public Shop Shop { get; set; } = new Shop();
        public int ProductId { get; set; }
        public string ShopName { get; set; } 

        public string PictureUrl { get; set; } //Picture Entity

        public string ProductTitle { get; set; } // Product

        public string ProductCategory { get; set; } // Category

        public int InventoryQnt { get; set; } // Inventory

        public int ProdductPrice { get; set; } // Price

        public int wage { get; set; } // Wage

        public int WageInventoryId { get; set; }

        public int AuctionDay { get; set; }
    }

    public class ShopProduct
    {
        
    }
}
