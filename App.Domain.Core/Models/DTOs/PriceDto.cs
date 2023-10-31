using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.DTOs
{
    public class PriceDtoInput
    {
        public int Id { get; set; }
        public int ProdutPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class PriceDtoOutput
    {
        public int ProdutPrice { get; set; }
    }
}
