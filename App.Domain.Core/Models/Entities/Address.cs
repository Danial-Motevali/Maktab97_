using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool IsDeleted { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
