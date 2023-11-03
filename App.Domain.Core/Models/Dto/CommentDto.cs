using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class CommentDtoInput
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime TimeOfCreate { get; set; }

        public bool IsDeleted { get; set; }
    }
    public class CommentDtoOutput
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
