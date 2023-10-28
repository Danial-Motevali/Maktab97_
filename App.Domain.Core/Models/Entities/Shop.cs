using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameOfCreator { get; set; }
        public DateTime TimeOfCreate { get; set; }
        public bool IsDeleted { get; set; }
        public int Medal { get; set; }

        public ICollection<Product> Products { get; set; }

        public int ProfilId { get; set; }
        public Profile profile { get; set; }
    }
}
