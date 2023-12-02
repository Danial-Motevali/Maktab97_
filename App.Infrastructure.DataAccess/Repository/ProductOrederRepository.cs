using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities;
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
    public class ProductOrederRepository : IProductOrderRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ProductOrederRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductOreder> Add(ProductOreder input, CancellationToken cancellation)
        {
            var address = await _db.productOreders.FirstOrDefaultAsync(x => x.Id == input.Id);

            if (address == null)
            {
                await _db.productOreders.AddAsync(input, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return input;
            }
            return address;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.productOreders.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<ProductOreder>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.productOreders.ToList();

            return addresses;
        }

        public async Task<ProductOreder> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.productOreders.FirstOrDefault(x => x.Id == Id);

            return address;
        }

        public async Task<List<ProductOreder>> GetOrderId(int OrderId, CancellationToken cancellation)
        {
            var allProductOrder = await GetAll(cancellation);
            var markList = new List<ProductOreder>();

            foreach (var prdouct in allProductOrder)
            {
                if (prdouct.OrederId == OrderId)
                {
                    markList.Add(prdouct);
                }
            }

            return markList;
        }

        public async Task<List<ProductOreder>> GetProductId(int ProductId, CancellationToken cancellation)
        {
            var allProductOrder = await GetAll(cancellation);
            var markList = new List<ProductOreder>();

            foreach(var prdouct in allProductOrder)
            {
                if(prdouct.ProductId == ProductId)
                {
                    markList.Add(prdouct);
                }
            }

            return markList;
        }

        public async Task<bool> Update(int Id, ProductOreder input, CancellationToken cancellation)
        {
            var address = _db.productOreders.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = input.Id;
                address.IsDeleted = input.IsDeleted;
                address.OrederId = input.OrederId;
                address.ProductId = input.ProductId;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
