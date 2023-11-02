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
        public async Task<bool> Add(CartDtoInput cartInput, CancellationToken cancellation)
        {
            var cart = await _db.Carts.FirstOrDefaultAsync(x => x.Id == cartInput.Id);

            if (cart != null)
            {
                var newCart = _mapper.Map<Cart>(cartInput);

                await _db.Carts.AddAsync(newCart, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var cart = await _db.Carts.FirstOrDefaultAsync(x => x.Id == Id);

            if (cart != null)
            {
                cart.IsActive = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<CartDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var carts = _db.Carts.ToList();
            var result = carts.Select(cart => _mapper.Map<CartDtoOutput>(cart)).ToList();

            return result;
        }

        public async Task<CartDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var cart = _db.Carts.FirstOrDefault(x => x.Id == Id);
            var getCart = _mapper.Map<CartDtoOutput>(cart);

            return getCart;
        }

        public async Task<bool> Update(int Id, CartDtoInput inputCart, CancellationToken cancellation)
        {
            var cart = _db.Carts.FirstOrDefault(x => x.Id == Id);

            if (cart != null)
            {
                cart.Id = inputCart.Id;
                cart.IsActive = inputCart.IsActive;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
