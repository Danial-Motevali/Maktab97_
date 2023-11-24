using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto.ControllerDto.Buyer
{
    public class BuyerSearchDto
    {
        public string? ProductTitle { get; set; }

        public string? ProductUrl { get; set; }

        public string? Category { get; set; }

        public string? SellerName { get; set; }

        public int ProductPrice { get; set; }

        public int SellerId { get; set; }

        public int ShopId { get; set; }

        public int ProductId { get; set; }
    }
}
