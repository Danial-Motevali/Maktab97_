using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public int ProdutPrice { get; set; }
        public bool IsDeleted { get; set; }

        public int WageId { get; set; }
        public Wage Wage { get; set; }

        
    }
}
