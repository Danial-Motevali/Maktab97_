using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _repository;
        public BuyerService(IBuyerRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(Buyer addressInput, CancellationToken cancellation)
        {
            return await _repository.Add(addressInput, cancellation);
        }

        public Buyer ByUserId(int UserId, CancellationToken cancellation)
        {
            var allBuyer = _repository.GetAll(cancellation);

            foreach (var buyer in allBuyer)
            {
                if (buyer.UserId == UserId)
                    return buyer;
            }

            return null;
        }

        //public async Task<bool> Delete(int Id, CancellationToken cancellation)
        //{
        //    var category = await _repository.GetById(Id, cancellation);
        //    if (category != null)
        //    {
        //        await _repository.Delete(Id, cancellation);
        //        return true;
        //    }
        //    return false;
        //}

        public  List<Buyer> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public async Task<Buyer> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        //public async Task<bool> Update(int Id, Buyer addressInput, CancellationToken cancellation)
        //{
        //    return await _repository.Update(Id, addressInput, cancellation);
        //}
    }
}
