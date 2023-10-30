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
    public class AuctionRepository : IAuctionRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public AuctionRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(AuctionDtoInput inputAuction)
        {
            var auction = await _db.Auctions.FirstOrDefaultAsync(x => x.Id == inputAuction.Id);

            if (auction != null)
            {
                var newAuction = _mapper.Map<Address>(inputAuction);

                await _db.AddAsync(newAuction);
                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id)
        {
            var auction = await _db.Auctions.FirstOrDefaultAsync(x => x.Id == Id);

            if (auction != null)
            {
                auction.IsDeleted = true;

                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<List<AuctionDtoOutput>> GetAll()
        {
            var auctions = _db.Auctions.ToList();
            var result = auctions.Select(auctions => _mapper.Map<AuctionDtoOutput>(auctions)).ToList();

            return result;
        }

        public async Task<AuctionDtoOutput> GetById(int Id)
        {
            var auction = _db.Auctions.FirstOrDefault(x => x.Id == Id);
            var getAuction = _mapper.Map<AuctionDtoOutput>(auction);

            return getAuction;
        }

        public async Task<bool> Update(int Id, AuctionDtoInput iputAction)
        {
            var auction = _db.Auctions.FirstOrDefault(x => x.Id == Id);

            if (auction != null)
            {
                auction.Id = iputAction.Id;
                auction.LastPrice = iputAction.LastPrice;
                auction.IsActive = iputAction.IsActive;

                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
