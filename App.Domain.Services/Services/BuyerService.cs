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
        private readonly IUserRepsitory _userRepsitory;
        public BuyerService(IBuyerRepository repository, IUserRepsitory userRepsitory)
        {
            _repository = repository;
            _userRepsitory = userRepsitory;
        }
        public async Task<Buyer> Add(Buyer addressInput, CancellationToken cancellation)
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

        public List<User> FindBuyerInUser(CancellationToken cancellation)
        {
            var allUser = _userRepsitory.GetAll(cancellation);
            var allBuyer = _repository.GetAll(cancellation);
            var buyerUser = new List<User>();

            foreach (var user in allUser)
            {
                foreach (var buyer in allBuyer)
                    if (user.Id == buyer.UserId)
                        buyerUser.Add(user);
            }

            return buyerUser;
        }

        public async Task<Buyer> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<bool> Update(int Id, Buyer addressInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, addressInput, cancellation);
        }
    }
}
