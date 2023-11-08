using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Models.Identity.Entites;

public class MyAdmin 
{
    public int Id { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public int UserId { get; set; }
    public User User { get; set; }
}
