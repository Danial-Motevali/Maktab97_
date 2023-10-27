using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Product { get; set; }
        public int Price { get; set; }
        public DateTime TimeOfCreate { get; set; }
    }
}
