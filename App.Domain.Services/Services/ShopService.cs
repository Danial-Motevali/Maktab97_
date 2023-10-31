using App.Domain.Core.Contract.Service;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class ShopService : IShopService
    {
        private readonly IShopService _repository;
        public ShopService(IShopService repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(ShopDtoInput shopInput)
        {
            return await _repository.Add(shopInput);
        }

        public async Task<bool> Delete(int Id)
        {
            var cart = await _repository.GetById(Id);
            if (cart != null)
            {
                await _repository.Delete(Id);
                return true;
            }
            return false;
        }

        public async Task<List<ShopDtoOutput>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<ShopDtoOutput> GetById(int Id)
        {
            return await _repository.GetById(Id);
        }

        public async Task<bool> Update(int Id, ShopDtoInput shopInput)
        {
            return await _repository.Update(Id, shopInput);
        }
    }
}
