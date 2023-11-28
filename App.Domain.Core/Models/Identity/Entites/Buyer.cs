using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Models.Identity.Entites;

public class Buyer 
{
    public int Id { get; set; }

    public ICollection<Address>? Addresses { get; set; }

    public ICollection<Cart>? carts { get; set; }

    public ICollection<Comment>? Comments { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}
