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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(Category inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Categories.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                await _db.Categories.AddAsync(address, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Categories.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public  List<Category> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Categories.ToList();

            return addresses;
        }

        public async Task<Category> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Categories.FirstOrDefault(x => x.Id == Id);

            return address;
        }

        public async Task<bool> Update(int Id, Category inputAddress, CancellationToken cancellation)
        {
            var address = _db.Categories.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.Title = inputAddress.Title;
                address.ParentId = inputAddress.ParentId;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
