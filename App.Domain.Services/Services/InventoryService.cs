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
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _repository;
        public InventoryService(IInventoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(Inventory addressInput, CancellationToken cancellation)
        {
            return await _repository.Add(addressInput, cancellation);
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var category = await _repository.GetById(Id, cancellation);
            if (category != null)
            {
                await _repository.Delete(Id, cancellation);
                return true;
            }
            return false;
        }

        public  List<Inventory> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public Inventory GetByAuctionId(int AuctionId, CancellationToken cancellation)
        {
            var allInventory = _repository.GetAll(cancellation);

            foreach (var inventory in allInventory)
            {
                if(inventory.AuctionId == AuctionId)
                    return inventory;
            }

            return null;
        }

        public async Task<Inventory> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<List<Inventory>> GetByPriceId(int PriceId, CancellationToken cancellation)
        {
            var allInventory = _repository.GetAll(cancellation);
            var markInventory = new List<Inventory>();

            foreach(var inventory in allInventory)
            {
                if(inventory.PriceId == PriceId)
                    markInventory.Add(inventory);
            }

            return markInventory;
        }

        public async Task<List<Inventory>> GetByProductId(int ProductId, CancellationToken cancellation)
        {
            var allInventory = _repository.GetAll(cancellation);
            var markInventory = new List<Inventory>();

            foreach (var inventory in allInventory)
            {
                if (inventory.ProductId == ProductId)
                    markInventory.Add(inventory);
            }

            return markInventory;
        }

        public async Task<List<Inventory>> GetByCartId(int CartId, CancellationToken cancellation)
        {
            var allInventory = _repository.GetAll(cancellation);
            var markInventory = new List<Inventory>();

            foreach (var inventory in allInventory)
            {
                if (inventory.CartId == CartId)
                    markInventory.Add(inventory);
            }

            return markInventory;
        }

        public List<Inventory> GetByShopId(int ShopId, CancellationToken cancellation)
        {
            var allInventory = _repository.GetAll(cancellation);
            var markInventory = new List<Inventory>();

            foreach (var inventory in allInventory)
            {
                if (inventory.ShopId == ShopId)
                    markInventory.Add(inventory);
            }

            return markInventory;
        }

        public async Task<bool> Update(int Id, Inventory addressInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, addressInput, cancellation);
        }
    }
}
