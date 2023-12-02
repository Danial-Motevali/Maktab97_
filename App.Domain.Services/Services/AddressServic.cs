using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class AddressServic : IAddressService
    {
        private readonly IAddressRepository _repository;
        public AddressServic(IAddressRepository repository)
        {
            _repository = repository;
        }
        public async Task<Address> Add(Address addressInput, CancellationToken cancellation)
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

        public  List<Address> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public List<Address> GetByAdminId(int AdminId, CancellationToken cancellation)
        {
            var allAdddress = _repository.GetAll(cancellation);
            var adminAddress = new List<Address>();

            foreach(var address in allAdddress)
            {
                if(address.MyAdminId == AdminId)
                    adminAddress.Add(address);
            }

            return adminAddress;
        }

        public List<Address> GetByBuyerId(int BuyerId, CancellationToken cancellation)
        {
            var allAdddress = _repository.GetAll(cancellation);
            var buyerAddress = new List<Address>();

            foreach (var address in allAdddress)
            {
                if (address.BuyerId == BuyerId)
                    buyerAddress.Add(address);
            }

            return buyerAddress;
        }

        public async Task<Address> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public List<Address> GetBySellerId(int SellerId, CancellationToken cancellation)
        {
            var allAdddress = _repository.GetAll(cancellation);
            var sellerAddress = new List<Address>();

            foreach (var address in allAdddress)
            {
                if (address.SellerId == SellerId)
                    sellerAddress.Add(address);
            }

            return sellerAddress;
        }

        public async Task<bool> Update(int Id, Address addressInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, addressInput, cancellation);
        }
    }
}
