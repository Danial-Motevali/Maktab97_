using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class CategoryDtoInput
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public int? ParentId { get; set; }

        public bool IsDeleted { get; set; }
    }
    public class CategoryDtoOutput
    {

        public string Title { get; set; } = null!;

        public int? ParentId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
