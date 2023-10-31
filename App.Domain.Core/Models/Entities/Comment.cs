using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime TimeOfCreate { get; set; }
        public bool IsDeleted { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
