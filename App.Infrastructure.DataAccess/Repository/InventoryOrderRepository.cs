﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities;
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
    public class InventoryOrderRepository : IInventoryOrderRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public InventoryOrderRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<InventoryOreder> Add(InventoryOreder input, CancellationToken cancellation)
        {
            var address = await _db.inventoryOreder.FirstOrDefaultAsync(x => x.Id == input.Id);

            if (address == null)
            {
                await _db.inventoryOreder.AddAsync(input, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return input;
            }
            return address;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.inventoryOreder.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<InventoryOreder>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.inventoryOreder.ToList();
            var mark = new List<InventoryOreder>();

            mark = addresses.Where(x => x.IsDeleted == false).ToList();

            return mark;
        }

        public async Task<InventoryOreder> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.inventoryOreder.FirstOrDefault(x => x.Id == Id && x.IsDeleted == false);

            return address;
        }

        public async Task<bool> Update(int Id, InventoryOreder input, CancellationToken cancellation)
        {
            var address = _db.inventoryOreder.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = input.Id;
                address.IsDeleted = input.IsDeleted;
                address.OrederId = input.OrederId;
                address.InventoryId = input.InventoryId;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
