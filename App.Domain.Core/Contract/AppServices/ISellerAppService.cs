using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Dto.ControllerDto;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.AppServices
{
    public interface ISellerAppService
    {
        Seller FindSeller(int UserId, CancellationToken cancellation);

        Shop FindShop(int SellerId, CancellationToken cancellation);

        Shop CreateAShop(ShopDtoOutput shop, CancellationToken cancellation);

        List<ShopDashBordDto> FillTheDto(Shop shop, CancellationToken cancellation);
    }
}
