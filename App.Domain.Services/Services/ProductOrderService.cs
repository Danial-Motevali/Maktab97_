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
    public class ProductOrderService : IProductOrederService
    {
        private readonly IProductOrderRepository _repository;
        public ProductOrderService(IProductOrderRepository productPicture)
        {
            _repository = productPicture;

        }
        public async Task<ProductOreder> Add(ProductOreder input, CancellationToken cancellation)
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

        public async Task<List<ProductOreder>> GetAll(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }

        public async Task<ProductOreder> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<List<ProductOreder>> GetByOrderId(int OrderId, CancellationToken cancellation)
        {
            return await _repository.GetOrderId(OrderId, cancellation);
        }

        public async Task<List<ProductOreder>> GetByProductId(int ProductId, CancellationToken cancellation)
        {
            return await _repository.GetProductId(ProductId, cancellation);
        }

        public async Task<bool> Update(int Id, ProductOreder input, CancellationToken cancellation)
        {
            return await _repository.Update(Id, input, cancellation);
        }
    }
}
