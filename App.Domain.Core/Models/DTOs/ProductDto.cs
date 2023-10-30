using App.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.DTOs
{
    public class ProductDtoInput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Qty { get; set; }
        public bool IsDeleted { get; set; }
        public bool HasPrice { get; set; }
    }
    public class ProductDtoOutput
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Qty { get; set; }
    }
}
