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
    public class InventoryOrederService : IInventoryOrederService
    {
        private readonly IInventoryOrderRepository _repository;
        public InventoryOrederService(IInventoryOrderRepository productPicture)
        {
            _repository = productPicture;

        }
        public async Task<InventoryOreder> Add(InventoryOreder input, CancellationToken cancellation)
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

        public async Task<List<InventoryOreder>> GetAll(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }

        public async Task<InventoryOreder> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<List<InventoryOreder>> GetByOrderId(int OrderId, CancellationToken cancellation)
        {
            var allOrder = await _repository.GetAll(cancellation);
            var markList = new List<InventoryOreder>();

            foreach (var order in allOrder)
            {
                if(order.OrederId == OrderId)
                    markList.Add(order);
            }

            return markList;
        }

        public async Task<List<InventoryOreder>> GetInventoryId(int InventoryId, CancellationToken cancellation)
        {
            var allOrder = await _repository.GetAll(cancellation);
            var markList = new List<InventoryOreder>();

            foreach (var order in allOrder)
            {
                if (order.InventoryId == InventoryId)
                    markList.Add(order);
            }

            return markList;
        }

        public async Task<bool> Update(int Id, InventoryOreder input, CancellationToken cancellation)
        {
            return await _repository.Update(Id, input, cancellation);
        }
    }
}
