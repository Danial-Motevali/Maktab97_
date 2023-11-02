﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using App.Domain.Core.Models.Entities;
using App.Infrastructure.Data.EF;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(ProductDtoInput inputProduct, CancellationToken cancellation)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == inputProduct.Id);

            if (product != null)
            {
                var newProduct = _mapper.Map<Product>(inputProduct);

                await _db.Products.AddAsync(newProduct, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var product = await _db.Products.FirstOrDefaultAsync(x => x.Id == Id);

            if (product != null)
            {
                product.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<ProductDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var products = _db.Products.ToList();
            var result = products.Select(product => _mapper.Map<ProductDtoOutput>(product)).ToList();

            return result;
        }

        public async Task<ProductDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == Id);
            var getProduct = _mapper.Map<ProductDtoOutput>(product);

            return getProduct;
        }

        public async Task<bool> Update(int Id, ProductDtoInput inputProduct, CancellationToken cancellation)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == Id);

            if (product != null)
            {
                product.Id = inputProduct.Id;
                product.Title = inputProduct.Title;
                product.Qty = inputProduct.Qty;
                product.IsDeleted = inputProduct.IsDeleted;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
