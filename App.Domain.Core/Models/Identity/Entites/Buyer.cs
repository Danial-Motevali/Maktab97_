using App.Domain.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace App.Domain.Core.Models.Identity.Entites;

public class Buyer : IdentityUser
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();

    public Cart? Cart { get; set; }

    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
