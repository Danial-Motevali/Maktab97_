using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Models.Identity.Entites;

public class Seller 
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LasName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public int MedalId { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();

    public Shop Id1 { get; set; } = null!;

    public Auction IdNavigation { get; set; } = null!;

    public ICollection<Medal> Medals { get; set; } = new List<Medal>();

    public ICollection<Wage> Wages { get; set; } = new List<Wage>();
}
