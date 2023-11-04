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
    public class PriceRepository : IPriceRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public PriceRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(PriceDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Prices.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                var newProduct = _mapper.Map<Price>(inputAddress);

                await _db.Prices.AddAsync(newProduct, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Prices.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<PriceDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Prices.ToList();
            var result = addresses.Select(address => _mapper.Map<PriceDtoOutput>(address)).ToList();

            return result;
        }

        public async Task<PriceDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Prices.FirstOrDefault(x => x.Id == Id);
            var getAddress = _mapper.Map<PriceDtoOutput>(address);

            return getAddress;
        }

        public async Task<bool> Update(int Id, PriceDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = _db.Prices.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.ProdutPrice = inputAddress.ProdutPrice;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
