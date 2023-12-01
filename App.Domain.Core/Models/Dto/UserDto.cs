using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } 

        public string LastName { get; set; } 

        public string UserName { get; set; }

        public string Email { get; set; }

        public int Wage { get; set; }
        public bool IsDeleted { get; set; }
    }
}
