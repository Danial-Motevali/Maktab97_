using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Models.Dto;
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
    public class BuyerRepository : IBuyerRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public BuyerRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(BuyerDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Buyers.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                var newProduct = _mapper.Map<Buyer>(inputAddress);

                await _db.Buyers.AddAsync(newProduct, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Buyers.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<BuyerDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Buyers.ToList();
            var result = addresses.Select(address => _mapper.Map<BuyerDtoOutput>(address)).ToList();

            return result;
        }

        public async Task<BuyerDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Buyers.FirstOrDefault(x => x.Id == Id);
            var getAddress = _mapper.Map<BuyerDtoOutput>(address);

            return getAddress;
        }

        public async Task<bool> Update(int Id, BuyerDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = _db.Buyers.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.FirstName = inputAddress.FirstName;
                address.LastName = inputAddress.LastName;
                address.PassWord = inputAddress.PassWord;
                address.Email = inputAddress.Email;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
