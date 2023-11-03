using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class AdminDtoInput
    {
        public int Id { get; set; }

        public string FirsName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PassWord { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
    public class AdminDtoOutput
    {

        public string FirsName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PassWord { get; set; } = null!;

    }
}
