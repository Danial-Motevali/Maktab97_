using App.Domain.Core.Entities;
using App.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IOrderRepository
    {
        Task<Order> Add(Order input, CancellationToken cancellation);

        Task<bool> Update(int Id, Order input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Order> GetById(int Id, CancellationToken cancellation);

        List<Order> GetAll(CancellationToken cancellation);

        Task<Order> GetByBuyerId(int BuyerId, CancellationToken cancellation);
    }
}
