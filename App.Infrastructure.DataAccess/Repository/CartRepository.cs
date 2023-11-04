﻿using App.Domain.Core.Contract.Repository;
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
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CartRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(CartDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Carts.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                var newProduct = _mapper.Map<Cart>(inputAddress);

                await _db.Carts.AddAsync(newProduct, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Carts.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsActive = false;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<CartDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Carts.ToList();
            var result = addresses.Select(address => _mapper.Map<CartDtoOutput>(address)).ToList();

            return result;
        }

        public async Task<CartDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Carts.FirstOrDefault(x => x.Id == Id);
            var getAddress = _mapper.Map<CartDtoOutput>(address);

            return getAddress;
        }

        public async Task<bool> Update(int Id, CartDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = _db.Carts.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
