using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto
{
    public class PictureDtoInput
    {
        public int Id { get; set; }

        public IFormFile Url { get; set; }

        public bool IsDeleted { get; set; }
    }
    public class PictureDtoOutput
    {
        public string Url { get; set; } = null!;
    }
}
