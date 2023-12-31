﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Infrastructure.Data.EF;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public async Task<Auction> Add(Auction inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Auctions.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address == null)
            {
                await _db.Auctions.AddAsync(inputAddress, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return inputAddress;
            }
            return address;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Auctions.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsActive = false;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public  List<Auction> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Auctions.ToList();
            var mark = new List<Auction>();

            mark = addresses.Where(x => x.IsDeletd == false).ToList();

            return mark;
        }

        public async Task<Auction> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Auctions.FirstOrDefault(x => x.Id == Id && x.IsDeletd == false);

            return address;
        }

        public async Task<bool> Update(int Id, Auction inputAddress, CancellationToken cancellation)
        {
            var address = _db.Auctions.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.LastPrice = inputAddress.LastPrice;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
