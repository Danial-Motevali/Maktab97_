using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.DTOs
{
    public class AuctionDtoInput
    {
        public int Id { get; set; }
        public int LastPrice { get; set; }
        public bool IsActive { get; set; }
        public DateTime TimeOfStart { get; set; }
        public DateTime TimeOfEnd { get; set; }
    }
    public class AuctionDtoOutput
    {
        public int LastPrice { get; set; }
    }
}
