using App.Domain.Core.Contract.Repository;
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
    public class SellerRepository : ISellerRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public SellerRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(SellerDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Sellers.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                var newProduct = _mapper.Map<Seller>(inputAddress);

                await _db.Sellers.AddAsync(newProduct, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        //public async Task<bool> Delete(int Id, CancellationToken cancellation)
        //{
        //    var address = await _db.Sellers.FirstOrDefaultAsync(x => x.Id == Id);

        //    if (address != null)
        //    {
        //        address.IsDeleted = true;

        //        await _db.SaveChangesAsync(cancellation);

        //        return true;
        //    }
        //    return false;
        //}

        public async Task<List<SellerDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Sellers.ToList();
            var result = addresses.Select(address => _mapper.Map<SellerDtoOutput>(address)).ToList();

            return result;
        }

        public async Task<SellerDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Sellers.FirstOrDefault(x => x.Id == Id);
            var getAddress = _mapper.Map<SellerDtoOutput>(address);

            return getAddress;
        }

        //public async Task<bool> Update(int Id, SellerDtoInput inputAddress, CancellationToken cancellation)
        //{
        //    var address = _db.Sellers.FirstOrDefault(x => x.Id == Id);

        //    if (address != null)
        //    {
        //        address.Id = inputAddress.Id;
        //        address.FirstName = inputAddress.FirstName;
        //        address.LasName = inputAddress.LasName;

        //        await _db.SaveChangesAsync(cancellation);
        //        return true;
        //    }

        //    return false;
        //}
    }
}
