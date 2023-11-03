namespace App.Domain.Core.Entities;

public class Admin
{
    public int Id { get; set; }

    public string FirsName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();
}
