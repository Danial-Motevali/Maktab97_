using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<Order> Add(Order input, CancellationToken cancellation)
        {
            return await _repository.Add(input, cancellation);
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var cart = await _repository.GetById(Id, cancellation);
            if (cart != null)
            {
                await _repository.Delete(Id, cancellation);
                return true;
            }
            return false;
        }

        public async Task<List<Order>> GetAll(CancellationToken cancellation)
        {
            return _repository.GetAll(cancellation);
        }

        public async Task<Order> GetByBuyerId(int BuyerId, CancellationToken cancellation)
        {
            return await _repository.GetByBuyerId(BuyerId, cancellation);
        }

        public async Task<Order> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<bool> Update(int Id, Order input, CancellationToken cancellation)
        {
            return await _repository.Update(Id, input, cancellation);
        }
    }
}
