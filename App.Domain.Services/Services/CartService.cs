using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(Cart cartInput, CancellationToken cancellation)
        {
            return await _repository.Add(cartInput, cancellation);
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var cart = await _repository.GetById(Id, cancellation);
            if (cart != null)
            {
                await _repository.Delete(Id, cancellation);
                return true;
            }
            return false;
        }

        public  List<Cart> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public async Task<List<Cart>> GetByBuyerId(int BuyerId, CancellationToken cancellation)
        {
            var markList = new List<Cart>();
            var allCart = _repository.GetAll(cancellation);

            foreach(var cat in allCart)
            {
                if(cat.BuyerId == BuyerId)
                    markList.Add(cat);
            }

            return markList;
        }

        public async Task<Cart> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<Cart> GetByInventoryId(int InventoryId, CancellationToken cancellation)
        {
            var markList = new Cart();
            var allCart = _repository.GetAll(cancellation);

            foreach (var cat in allCart)
            {
                if (cat.InventoryId == InventoryId)
                    return cat;
            }

            return null;
        }

        public async Task<bool> Update(int Id, Cart cartInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, cartInput, cancellation);
        }
    }
}
