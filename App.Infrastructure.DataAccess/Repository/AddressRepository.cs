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
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public AddressRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(Address inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Addresses.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address == null)
            {
                await _db.Addresses.AddAsync(inputAddress, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Addresses.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public  List<Address> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Addresses.ToList();

            return addresses;
        }

        public async Task<Address> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Addresses.FirstOrDefault(x => x.Id == Id);

            return address;
        }

        public async Task<bool> Update(int Id, Address inputAddress, CancellationToken cancellation)
        {
            var address = _db.Addresses.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.City = inputAddress.City;
                address.Street = inputAddress.Street;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
