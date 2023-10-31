using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.DTOs
{
    public class PictureDtoInput
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class PictureDtoOutput
    {
        public string Url { get; set; }
    }
}
