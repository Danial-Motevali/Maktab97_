using App.Domain.Core.Contract.Service;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    internal class WageService : IWageService
    {
        private readonly IWageService _repository;
        public WageService(IWageService repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(WageDtoInput wageInput)
        {
            return await _repository.Add(wageInput);
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

        public async Task<List<WageDtoOutput>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<WageDtoOutput> GetById(int Id)
        {
            return await _repository.GetById(Id);
        }

        public async Task<bool> Update(int Id, WageDtoInput wageInput)
        {
            return await _repository.Update(Id, wageInput);
        }
    }
}
