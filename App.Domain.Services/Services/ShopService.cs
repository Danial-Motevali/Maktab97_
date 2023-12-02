using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopRepository _repository;
        public ShopService(IShopRepository repository)
        {
            _repository = repository;
        }
        public async Task<Shop> Add(Shop shopInput, CancellationToken cancellation)
        {
            return await _repository.Add(shopInput, cancellation);
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

        public  List<Shop> GetAll(CancellationToken cancellation)
        {
            var rsult =  _repository.GetAll(cancellation);

            return rsult;
        }

        public async Task<Shop> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public Shop GetBySellerId(int SellerId, CancellationToken cancellation)
        {
            var allShops = _repository.GetAll(cancellation);

            foreach (var shop in allShops)
            {
                if(shop.SellerId == SellerId)
                    return shop;
            }

            return null;
        }

        public async Task<bool> Update(int Id, Shop shopInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, shopInput, cancellation);
        }
    }
}
