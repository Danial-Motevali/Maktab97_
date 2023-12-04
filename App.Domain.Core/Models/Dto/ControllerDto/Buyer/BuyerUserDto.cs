using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto.ControllerDto.Buyer
{
    public class BuyerUserDto
    {
        public int? Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserName {get; set;}

        public string? Email { get; set;}

        public ICollection<BuyerUserCartDto>? Product { get; set; }
    }

    public class BuyerUserCartDto
    {
        public string Title { get; set; }

        public int Price { get; set; }

        public string Url { get; set; }
    }
}
