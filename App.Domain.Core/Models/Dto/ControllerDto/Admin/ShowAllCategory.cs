using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Dto.ControllerDto.Admin
{
    public class ShowAllCategory
    {
        public string Title { get; set; }

        public string PatentTilte { get; set; }

        public bool IsDeleted { get; set; }

        public string Parent { get; set; }
    }
}
