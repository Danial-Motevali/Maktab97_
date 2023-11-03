using App.Domain.Core.Entities;

namespace App.Domain.Core.Models.Dto
{
    public class CartDtoInput
    {
        public int Id { get; set; }

        public bool IsActive { get; set; }

        public DateTime TimeOfCreate { get; set; }

    }
    public class CartDtoOutput
    {
    }
}
