using App.Domain.Core.Models.Entities;
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
        public bool IsActive { get; set; }
        public DateTime TimeOfCreate { get; set; }
    }
    public class CartDtoOutput
    {
        public bool IsActive { get; set; }
    }
}
