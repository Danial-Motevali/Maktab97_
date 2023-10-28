using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.DTOs
{
    public class AddressDtoInput
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
    public class AddressDtoOutPut
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
}
