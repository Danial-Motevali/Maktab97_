using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string position { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; } 

        public bool HasShop { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }

        public bool HasCart { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
