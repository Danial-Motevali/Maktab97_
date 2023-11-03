using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class SellerDtoInput
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LasName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PassWord { get; set; } = null!;

        public int MedalId { get; set; }

        public bool IsDeleted { get; set; }
    }
    public class SellerDtoOutput
    {
        public string FirstName { get; set; } = null!;

        public string LasName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PassWord { get; set; } = null!;

    }
}
