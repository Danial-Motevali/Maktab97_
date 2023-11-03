using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class WageDtoInput
    {
        public int Id { get; set; }

        public int HowMuch { get; set; }

        public bool IsDeleted { get; set; }

        public int UserId { get; set; }
    }
    public class WageDtoOutput
    {
        public int HowMuch { get; set; }

    }
}
