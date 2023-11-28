namespace App.Domain.Core.Entities;

public class ProductPicture
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? PictureId { get; set; }

    public Picture? Picture { get; set; } 

    public Product? Product { get; set; } 
}
