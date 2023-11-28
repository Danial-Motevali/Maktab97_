using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto.ControllerDto.Buyer
{
    public class AuctionDto
    {
        public int? SellerId { get; set; }

        public int? AuctionId { get; set; }

        public string? ProductName { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? TimeOfStart { get; set; }

        public DateTime? TimeOfEnd { get; set; }

        public int? LastPrice { get; set; }
    }
}
