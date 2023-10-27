using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Auction
    {
        public int Id { get; set; }
        public int LastPrice { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeOfStart { get; set; }
        public DateTime TimeOfEnd { get; set;}
    }
}
