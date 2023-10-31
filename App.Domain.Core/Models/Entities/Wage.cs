using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Wage
    {
        [Key]
        public int Id { get; set; }
        public int HowMuch { get; set; }
        public bool IsDeleted { get; set; }
    }
}
