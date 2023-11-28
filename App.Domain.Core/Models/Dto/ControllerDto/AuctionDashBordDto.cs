using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto.ControllerDto
{
    public class AuctionDashBordDto
    {
        public int SellerId { get; set; }

        public int ProductId { get; set; }

        public int AuctionId { get; set; }

        public string PictureUrl { get; set; } 

        public string ProductTitle { get; set; } 

        public string ProductCategory { get; set; } 

        public DateTime TimeOfEnd { get; set; }

        public int InventoryQnt { get; set; } 

        public int LastPrice { get; set; } 

        public int wage { get; set; } 
    }
}
