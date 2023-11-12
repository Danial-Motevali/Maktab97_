using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.AppServices
{
    public interface IAdminAppServices
    {
        int FindSeller(int UserId ,CancellationToken cancellation);
        int FindSellerShop(int SellerSId,CancellationToken cancellation);
        List<User> FindAllSeller(CancellationToken cancellation);
        List<Inventory> FindInventoryByShopId(int ShopSId,CancellationToken cancellation);
        List<Product> FindProductByProductId(List<Inventory> SellerInventory, CancellationToken cancellation);
        bool DeleteProduct(int ProductId, CancellationToken cancellation);
    }
}
