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
        public async Task<bool> Add(WageDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Wages.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                var newProduct = _mapper.Map<Wage>(inputAddress);

                await _db.Wages.AddAsync(newProduct, cancellation);
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

        public async Task<List<WageDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Wages.ToList();
            var result = addresses.Select(address => _mapper.Map<WageDtoOutput>(address)).ToList();

            return result;
        }

        public async Task<WageDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Wages.FirstOrDefault(x => x.Id == Id);
            var getAddress = _mapper.Map<WageDtoOutput>(address);

            return getAddress;
        }

        public async Task<bool> Update(int Id, WageDtoInput inputAddress, CancellationToken cancellation)
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
