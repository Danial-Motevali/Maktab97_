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
    public class MedalRepository : IMedalRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public MedalRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(Medal inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Medals.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                await _db.Medals.AddAsync(address, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Medals.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                _db.Medals.Remove(address);

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<Medal>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Medals.ToList();

            return addresses;
        }

        public async Task<Medal> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Medals.FirstOrDefault(x => x.Id == Id);

            return address;
        }

        public async Task<bool> Update(int Id, Medal inputAddress, CancellationToken cancellation)
        {
            var address = _db.Medals.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.Rank = inputAddress.Rank;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
