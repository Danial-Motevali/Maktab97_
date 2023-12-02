using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IInventoryService
    {
        Task<Inventory> Add(Inventory input, CancellationToken cancellation);

        Task<bool> Update(int Id, Inventory input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Inventory> GetById(int Id, CancellationToken cancellation);

        List<Inventory> GetAll(CancellationToken cancellation);

        Task<List<Inventory>> GetByPriceId(int PriceId, CancellationToken cancellation);

        Task<List<Inventory>> GetByProductId(int ProductId, CancellationToken cancellation);

        List<Inventory> GetByShopId(int ShopId, CancellationToken cancellation);

        Inventory GetByAuctionId(int AuctionId, CancellationToken cancellation);
    }
}
