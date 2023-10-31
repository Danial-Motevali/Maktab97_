using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime TimeOfCreate { get; set; }
        public bool IsDeleted { get; set; }
        public int Medal { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
