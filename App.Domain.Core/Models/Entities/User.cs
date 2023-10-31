using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public bool IsDeleted { get; set; }

        public int? ShopId { get; set; }
        public Shop? Shop { get; set; }

        public int? CartId { get; set; }
        public Cart? Cart { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
