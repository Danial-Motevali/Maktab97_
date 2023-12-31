﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Identity.Entites;
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
    public class UserRepsitory : IUserRepsitory
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public UserRepsitory(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<User> Add(User inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Users.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address == null)
            {
                await _db.Users.AddAsync(inputAddress, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return inputAddress;
            }
            return address;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Users.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public List<User> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Users.ToList();
            var mark = new List<User>();

            mark = addresses.Where(x => x.IsDeleted == false).ToList();

            return mark;
        }

        public async Task<User> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Users.FirstOrDefault(x => x.Id == Id && x.IsDeleted == false);

            return address;
        }

        public async Task<bool> Update(int Id, User inputAddress, CancellationToken cancellation)
        {
            var address = _db.Shops.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
