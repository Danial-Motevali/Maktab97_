using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Identity.Entites
{
    public class User : IdentityUser<int>
    {
        public string? FirstName { get; set; } 

        public string? LastName { get; set; } 

        public bool IsDeleted { get; set; } = false;

        public Potion? Potion { get; set; }
    }

    public enum Potion
    {
        Buyer,
        Seller,
        Admin,
        Owner
    }
}
