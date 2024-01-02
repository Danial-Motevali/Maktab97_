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
        public async Task<Product> Add(Product inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Products.FirstOrDefaultAsync(x => x.Title == inputAddress.Title);

            if (address == null)
            {
                await _db.Products.AddAsync(inputAddress, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return inputAddress;
            }
            return address;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = GetById(Id, cancellation).Result;

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public List<Product> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Products.ToList();
            var mark = new List<Product>();

            mark = addresses.Where(x => x.IsDeleted == false).ToList();

            return mark;
        }

        public async Task<Product> GetById(int? Id, CancellationToken cancellation)
        {
            var address = _db.Products.FirstOrDefault(x => x.Id == Id && x.IsDeleted == false);

            return address;
        }

        public async Task<bool> Update(int Id, Product inputAddress, CancellationToken cancellation)
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
