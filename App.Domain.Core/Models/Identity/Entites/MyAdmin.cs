using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace App.Domain.Core.Models.Identity.Entites;

public class MyAdmin 
{
    public int Id { get; set; }

    public string FirsName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}
