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
    public class PriceRepository : IPriceRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public PriceRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(PriceDtoInput inputPrice)
        {
            var price = await _db.Prices.FirstOrDefaultAsync(x => x.Id == inputPrice.Id);

            if (price != null)
            {
                var newPrice = _mapper.Map<Price>(inputPrice);

                await _db.AddAsync(newPrice);
                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id)
        {
            var price = await _db.Prices.FirstOrDefaultAsync(x => x.Id == Id);

            if (price != null)
            {
                price.IsDeleted = true;

                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<List<PriceDtoOutput>> GetAll()
        {
            var price = _db.Prices.ToList();
            var result = price.Select(prices => _mapper.Map<PriceDtoOutput>(prices)).ToList();

            return result;
        }

        public async Task<PriceDtoOutput> GetById(int Id)
        {
            var price = _db.Prices.FirstOrDefault(x => x.Id == Id);
            var getPrice = _mapper.Map<PriceDtoOutput>(price);

            return getPrice;
        }

        public async Task<bool> Update(int Id, PriceDtoInput inputPrice)
        {
            var price = _db.Prices.FirstOrDefault(x => x.Id == Id);

            if (price != null)
            {
                price.Id = inputPrice.Id;
                price.ProdutPrice = inputPrice.ProdutPrice;

                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
