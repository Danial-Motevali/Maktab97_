using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.DTOs
{
    public class WageDtoInput
    {
        public int Id { get; set; }
        public int NumberOf { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class WageDtoOutput
    {
        public int NumberOf { get; set; }
        public int Price { get; set; }
    }
}
