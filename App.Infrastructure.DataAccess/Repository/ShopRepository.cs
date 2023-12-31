﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities;
using App.Infrastructure.Data.EF;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.DataAccess.Repository
{
    public class ShopRepository : IShopRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ShopRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Shop> Add(Shop inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Shops.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address == null)
            {
                await _db.Shops.AddAsync(inputAddress);
                await _db.SaveChangesAsync();

                return inputAddress;
            }
            return address;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Shops.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public List<Shop> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Shops.ToList();
            var mark = new List<Shop>();

            mark = addresses.Where(x => x.IsDeleted == false).ToList();

            return mark;
        }

        public async Task<Shop> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Shops.FirstOrDefault(x => x.Id == Id && x.IsDeleted == false);

            return address;
        }

        public async Task<bool> Update(int Id, Shop inputAddress, CancellationToken cancellation)
        {
            var address = _db.Shops.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.Name = inputAddress.Name;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
