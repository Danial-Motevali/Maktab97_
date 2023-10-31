using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Models.DTOs;
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
        public async Task<bool> Add(AddressDtoInput addressInput)
        {
            return await _repository.Add(addressInput);
        }

        public async Task<bool> Delete(int Id)
        {
            var category = await _repository.GetById(Id);
            if (category != null)
            {
                await _repository.Delete(Id);
                return true;
            }
            return false;
        }

        public async Task<List<AddressDtoOutPut>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<AddressDtoOutPut> GetById(int Id)
        {
            return await _repository.GetById(Id);
        }

        public async Task<bool> Update(int Id, AddressDtoInput addressInput)
        {
            return await _repository.Update(Id, addressInput);
        }
    }
}
