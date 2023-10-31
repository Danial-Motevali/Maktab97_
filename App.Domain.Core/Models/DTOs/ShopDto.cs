using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.DTOs
{
    public class ShopDtoInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Medal { get; set; }
    }
    public class ShopDtoOutput
    {
        public string Name { get; set; }
        public string NameOfCreator { get; set; }
        public int Medal { get; set; }
    }
}
