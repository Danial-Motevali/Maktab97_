using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime TimeOfCreate { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
