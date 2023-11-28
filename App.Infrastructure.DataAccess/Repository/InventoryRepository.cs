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
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public InventoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(Inventory inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Inventories.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address == null)
            {
                await _db.Inventories.AddAsync(inputAddress, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Inventories.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public  List<Inventory> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Inventories.ToList();

            return addresses;
        }

        public async Task<Inventory> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Inventories.FirstOrDefault(x => x.Id == Id);

            return address;
        }

        public async Task<bool> Update(int Id, Inventory inputAddress, CancellationToken cancellation)
        {
            var address = _db.Inventories.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.Qnt = inputAddress.Qnt;
                address.IsDeleted = inputAddress.IsDeleted;
                address.AuctionId = inputAddress.AuctionId;
                address.ProductId = inputAddress.ProductId;
                address.ShopId = inputAddress.ShopId;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
