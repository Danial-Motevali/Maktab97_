using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Models.Identity.Entites;

public class Seller 
{
    public int Id { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();

    public ICollection<Medal> Medals { get; set; } = new List<Medal>();

    public ICollection<Wage> Wages { get; set; } = new List<Wage>();
    public int UserId { get; set; }
    public User User { get; set; }
}
