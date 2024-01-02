using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Models.Identity.Entites;

public class Seller 
{
    public int Id { get; set; }

    public ICollection<Address>? Addresses { get; set; } 

    public ICollection<Medal>? Medals { get; set; } 

    public ICollection<Wage>? Wages { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }

    public bool IsDeleted { get; set; } = false;
}
