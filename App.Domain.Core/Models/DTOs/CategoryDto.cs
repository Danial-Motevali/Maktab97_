using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.DTOs
{
    public class CategoryDtoInput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
    }
    public class CategoryDtoOutput
    {
        public string Title { get; set; }
    }
}
