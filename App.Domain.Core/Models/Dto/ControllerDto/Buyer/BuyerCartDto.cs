﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto.ControllerDto.Buyer
{
    public class BuyerCartDto
    {
        public int? CartId { get; set; }

        public int? BuyerId { get; set; }

        public int? InventoryId { get; set; }

        public int? ProductId { get; set; }

        public string? ProdutName { get; set; }

        public int? ProductPrice { get; set; }

        public DateTime? CreatedDate { get; set; } 

        public string? Url { get; set; }
    }
}
