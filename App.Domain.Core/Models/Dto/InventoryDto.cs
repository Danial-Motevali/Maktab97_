using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class InventoryDtoInput
    {
        public int Id { get; set; }

        public int ShopId { get; set; }

        public int ProductId { get; set; }

        public int PriceId { get; set; }

        public int Qnt { get; set; }

        public int AuctionId { get; set; }

        public int CartId { get; set; }

        public bool IsDeleted { get; set; }
    }
    public class InventoryDtoOutput
    {
        public int Qnt { get; set; }

    }
}
