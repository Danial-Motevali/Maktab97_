using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(ProductDtoInput productInput)
        {
            return await _repository.Add(productInput);
        }

        public async Task<bool> Delete(int Id)
        {
            var cart = await _repository.GetById(Id);
            if (cart != null)
            {
                await _repository.Delete(Id);
                return true;
            }
            return false;
        }

        public async Task<List<ProductDtoOutput>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ProductDtoOutput> GetById(int Id)
        {
            return await _repository.GetById(Id);
        }

        public async Task<bool> Update(int Id, ProductDtoInput productInput)
        {
            return await _repository.Update(Id, productInput);
        }
    }
}
