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
        public async Task<bool> Add(InventoryDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Inventories.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                var newProduct = _mapper.Map<Inventory>(inputAddress);

                await _db.Inventories.AddAsync(newProduct, cancellation);
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

        public async Task<List<InventoryDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Inventories.ToList();
            var result = addresses.Select(address => _mapper.Map<InventoryDtoOutput>(address)).ToList();

            return result;
        }

        public async Task<InventoryDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Inventories.FirstOrDefault(x => x.Id == Id);
            var getAddress = _mapper.Map<InventoryDtoOutput>(address);

            return getAddress;
        }

        public async Task<bool> Update(int Id, InventoryDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = _db.Inventories.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.Qnt = inputAddress.Qnt;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
