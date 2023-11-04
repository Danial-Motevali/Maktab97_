using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
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
        public async Task<bool> Add(ProductDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Products.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                var newProduct = _mapper.Map<Product>(inputAddress);

                await _db.Products.AddAsync(newProduct, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Products.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<ProductDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Products.ToList();
            var result = addresses.Select(address => _mapper.Map<ProductDtoOutput>(address)).ToList();

            return result;
        }

        public async Task<ProductDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Products.FirstOrDefault(x => x.Id == Id);
            var getAddress = _mapper.Map<ProductDtoOutput>(address);

            return getAddress;
        }

        public async Task<bool> Update(int Id, ProductDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = _db.Products.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.Title = inputAddress.Title;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
