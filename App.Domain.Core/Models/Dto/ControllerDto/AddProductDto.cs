using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto.ControllerDto
{
    public class AddProductDto
    {
        //input from user
        public string? ProductTitle { get; set; }

        public IFormFile? PictureUrlFile { get; set; }
        public string? PictureUrl { get; set; }

        public int? ProductPrice { get; set; }

        public string ProductCategory { get; set; }

        public int Qnt { get; set; }

        public List<Category> category { get; set; }

        //under the seen sh
        public int? ShopId { get; set; }


    }
}
