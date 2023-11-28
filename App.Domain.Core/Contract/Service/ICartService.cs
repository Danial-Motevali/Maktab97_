using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface ICartService
    {
        Task<bool> Add(Cart input, CancellationToken cancellation);

        Task<bool> Update(int Id, Cart input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Cart> GetById(int Id, CancellationToken cancellation);

        Task<List<Cart>> GetByBuyerId(int BuyerId, CancellationToken cancellation);

        Task<Cart> GetByInventoryId(int InventoryId, CancellationToken cancellation);

        List<Cart> GetAll(CancellationToken cancellation);
    }
}
