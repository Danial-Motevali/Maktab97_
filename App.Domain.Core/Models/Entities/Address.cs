using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Core.Entities;

public class Address
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public int UserId { get; set; }

    public  Admin User { get; set; } = null!;

    public  Seller User1 { get; set; } = null!;

    public  Buyer UserNavigation { get; set; } = null!;
}
