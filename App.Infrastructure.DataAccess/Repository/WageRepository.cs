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
    public class WageRepository : IWageRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public WageRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(Wage inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Wages.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                await _db.Wages.AddAsync(address, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Wages.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public List<Wage> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Wages.ToList();

            return addresses;
        }

        public async Task<Wage> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Wages.FirstOrDefault(x => x.Id == Id);

            return address;
        }

        public async Task<bool> Update(int Id, Wage inputAddress, CancellationToken cancellation)
        {
            var address = _db.Wages.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.HowMuch = inputAddress.HowMuch;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
