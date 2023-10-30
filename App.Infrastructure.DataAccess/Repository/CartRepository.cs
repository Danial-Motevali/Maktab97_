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
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CartRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(CartDtoInput cartInput)
        {
            var cart = await _db.Carts.FirstOrDefaultAsync(x => x.Id == cartInput.Id);

            if (cart != null)
            {
                var newCart = _mapper.Map<Address>(cartInput);

                await _db.AddAsync(newCart);
                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id)
        {
            var cart = await _db.Carts.FirstOrDefaultAsync(x => x.Id == Id);

            if (cart != null)
            {
                cart.IsDeleted = true;

                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<List<AddressDtoOutPut>> GetAll()
        {
            var addresses = _db.Addresses.ToList();
            var result = addresses.Select(address => _mapper.Map<AddressDtoOutPut>(address)).ToList();

            return result;
        }

        public async Task<AddressDtoOutPut> GetById(int Id)
        {
            var address = _db.Addresses.FirstOrDefault(x => x.Id == Id);
            var getAddress = _mapper.Map<AddressDtoOutPut>(address);

            return getAddress;
        }

        public async Task<bool> Update(int Id, AddressDtoInput inputAddress)
        {
            var address = _db.Addresses.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.City = inputAddress.City;
                address.Street = inputAddress.Street;

                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
