using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto.ControllerDto.Admin
{
    public class ShowProductDto
    {
        public string ProductName { get; set; }

        public string ProductCategory { get; set; }

        public int ProductPrice { get; set; }

        public string Url { get; set; }

        public bool IsDeletd { get; set; }

        public int Wage { get; set; }

        public int InventoryId { get; set; }

        public int SellerId { get; set; }

        public int ProductId { get; set; }
    }
}
