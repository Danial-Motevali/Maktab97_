using App.Domain.Core.Contract.Repository;
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
    public class ShopRepository : IShopRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ShopRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(ShopDtoInput inputShop, CancellationToken cancellation)
        {
            var shop = await _db.Shops.FirstOrDefaultAsync(x => x.Id == inputShop.Id);

            if (shop != null)
            {
                var newShop = _mapper.Map<Shop>(inputShop);

                await _db.Shops.AddAsync(newShop, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var shop = await _db.Shops.FirstOrDefaultAsync(x => x.Id == Id);

            if (shop != null)
            {
                shop.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<ShopDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var shops = _db.Shops.ToList();
            var result = shops.Select(shop => _mapper.Map<ShopDtoOutput>(shop)).ToList();

            return result;
        }

        public async Task<ShopDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var shop = _db.Addresses.FirstOrDefault(x => x.Id == Id);
            var getShop = _mapper.Map<ShopDtoOutput>(shop);

            return getShop;
        }

        public async Task<bool> Update(int Id, ShopDtoInput inputShop, CancellationToken cancellation)
        {
            var shop = _db.Shops.FirstOrDefault(x => x.Id == Id);

            if (shop != null)
            {
                shop.Id = inputShop.Id;
                shop.Name = inputShop.Name;
                shop.Medal = inputShop.Medal;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
