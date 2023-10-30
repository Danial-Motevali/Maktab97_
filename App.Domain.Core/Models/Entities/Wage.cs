using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Wage
    {
        public int Id { get; set; }
        public int NumberOf { get; set; }
        public bool IsDeleted { get; set; }
    }
}
