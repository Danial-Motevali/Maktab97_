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
        public async Task<Cart> Add(Cart inputAddress, CancellationToken cancellation)
        {
            //var address = await _db.Carts.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            //if (address == null)
            //{
                await _db.Carts.AddAsync(inputAddress, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return inputAddress;
            //}
            //return address;
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

        public  List<Cart> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Carts.ToList();
            var mark = new List<Cart>();

            mark = addresses.Where(x => x.IsDeleted == false).ToList();

            return mark;
        }

        public async Task<Cart> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Carts.FirstOrDefault(x => x.Id == Id && x.IsDeleted == false);

            return address;
        }

        public async Task<bool> Update(int Id, Cart inputAddress, CancellationToken cancellation)
        {
            var address = _db.Carts.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.IsActive = inputAddress.IsActive;
                address.TimeOfCreate = inputAddress.TimeOfCreate;
                address.BuyerId = inputAddress.BuyerId;
                address.InventoryId = inputAddress.InventoryId;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
