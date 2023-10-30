using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.DTOs
{
    public class CartDtoInput
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class CartDtoOutput
    {
        public string Product { get; set; }
        public int Price { get; set; }
    }
}
