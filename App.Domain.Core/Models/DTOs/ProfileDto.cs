using App.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.DTOs
{
    public class ProfileDtoInput
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string position { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool HasShop { get; set; }
        public bool HasCart { get; set; }
    }
    public class ProfileDtoOutput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string position { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
    }

}
