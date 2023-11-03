using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class ProductDtoInput
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }
    }
    public class ProductDtoOutput
    {
        public string Title { get; set; } = null!;


    }
}
