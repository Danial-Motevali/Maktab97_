using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class SellerDtoInput
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class SellerDtoOutput
    {
        public int Id { get; set; }
        public string PassWord { get; set; } = null!;

    }
}
