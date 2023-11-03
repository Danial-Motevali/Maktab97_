using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class AddressDtoInput
    {
        public int Id { get; set; }

        public string City { get; set; } = null!;

        public string Street { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
    public class AddressDtoOutput
    {

        public string City { get; set; } = null!;

        public string Street { get; set; } = null!;
    }
}
