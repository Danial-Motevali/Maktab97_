namespace App.Domain.Core.Entities;

public class Picture
{
    public int Id { get; set; }

    public string? Url { get; set; }

    public bool? IsDeleted { get; set; }

    public ICollection<ProductPicture>? ProductPictures { get; set; } 
}
