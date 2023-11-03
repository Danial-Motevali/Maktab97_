namespace App.Domain.Core.Models.Dto
{
    public class MedalDtoInput
    {
        public int Id { get; set; }

        public string Rank { get; set; } = null!;

        public int UserId { get; set; }

    }
    public class MedalDtoOutput
    {
        public string Rank { get; set; } = null!;
    }
}
