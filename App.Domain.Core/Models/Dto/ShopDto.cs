namespace App.Domain.Core.Models.Dto
{
    public class ShopDtoInput
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime TimeOfCreate { get; set; }

        public bool IsDeleted { get; set; }
    }
    public class ShopDtoOutput
    {
        public string Name { get; set; } = null!;

    }
}
