using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto.ControllerDto.Buyer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.AppServices
{
    public interface IBuyerAppService
    {
        Task<List<BuyerSearchDto>> Search(string UserName, CancellationToken cancellation);
    }
}
