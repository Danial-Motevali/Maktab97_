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
    public class WageService : IWageService
    {
        private readonly IWageRepository _repository;
        public WageService(IWageRepository repository)
        {
            _repository = repository;
        }
        public async Task<Wage> Add(Wage wageInput, CancellationToken cancellation)
        {
            return await _repository.Add(wageInput, cancellation);
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

        public  List<Wage> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public async Task<Wage> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<List<Wage>> GetAllBySellerId(int SellerId, CancellationToken cancellation)
        {
            var allWage =  _repository.GetAll(cancellation);
            var sellerWage = new List<Wage>();

            foreach(var wage in allWage)
            {
                if(wage.SellerId == SellerId && wage.IsDeleted == false)
                    sellerWage.Add(wage);
            }

            return sellerWage;
        }

        public async Task<bool> Update(int Id, Wage wageInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, wageInput, cancellation);
        }

        public async Task<Wage> GetAllByInventoyId(int InventorId, CancellationToken cancellation)
        {
            var allWage = _repository.GetAll(cancellation);
            var inventoryWage = new Wage();

            foreach (var wage in allWage)
            {
                if (wage.InventoryId == InventorId && wage.IsDeleted == false && wage.IsPaid == false)
                    return wage;
            }

            return null;
        }
    }
}
