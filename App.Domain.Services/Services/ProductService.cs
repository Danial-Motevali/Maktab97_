﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
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
        public async Task<Product> Add(Product productInput, CancellationToken cancellation)
        {
            return await _repository.Add(productInput, cancellation);
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

        public  List<Product> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public async Task<Product> GetById(int? Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<List<Product>> GetCategoryId(int CategoryId, CancellationToken cancellation)
        {
            var allProduct = _repository.GetAll(cancellation);
            var markProduct = new List<Product>();

            foreach (var product in allProduct)
            {
                if(product.CategoryId == CategoryId)
                    markProduct.Add(product);
            }

            return markProduct;
        }

        public async Task<bool> Update(int Id, Product productInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, productInput, cancellation);
        }
    }
}
