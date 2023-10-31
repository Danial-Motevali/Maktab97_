using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public bool IsDeleted { get; set; }

    }
}
