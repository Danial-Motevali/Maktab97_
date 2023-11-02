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
    public class WageRepository : IWageRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public WageRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(WageDtoInput inputWage, CancellationToken cancellation)
        {
            var wage = await _db.Wages.FirstOrDefaultAsync(x => x.Id == inputWage.Id);

            if (wage != null)
            {
                var newWage = _mapper.Map<Wage>(inputWage);

                await _db.Wages.AddAsync(newWage, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var wage = await _db.Wages.FirstOrDefaultAsync(x => x.Id == Id);

            if (wage != null)
            {
                wage.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<WageDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var wages = _db.Wages.ToList();
            var result = wages.Select(Wage => _mapper.Map<WageDtoOutput>(Wage)).ToList();

            return result;
        }

        public async Task<WageDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var wage = _db.Wages.FirstOrDefault(x => x.Id == Id);
            var getWage = _mapper.Map<WageDtoOutput>(wage);

            return getWage;
        }

        public async Task<bool> Update(int Id, WageDtoInput inputWage, CancellationToken cancellation)
        {
            var wage = _db.Wages.FirstOrDefault(x => x.Id == Id);

            if (wage != null)
            {
                wage.Id = inputWage.Id;
                wage.HowMuch = inputWage.HowMuch;
                wage.IsDeleted = inputWage.IsDeleted;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
