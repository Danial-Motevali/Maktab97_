using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class ProductPictureDtoInput
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int PictureId { get; set; }
    }
    public class ProductPictureDtoOutput
    {
        public int ProductId { get; set; }

        public int PictureId { get; set; }
    }
}
