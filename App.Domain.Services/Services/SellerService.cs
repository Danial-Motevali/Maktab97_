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
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _repository;
        private readonly IUserRepsitory _userRepsitory;
        public SellerService(ISellerRepository repository, IUserRepsitory userRepsitory)
        {
            _repository = repository;
            _userRepsitory = userRepsitory;
        }
        public async Task<bool> Add(Seller addressInput, CancellationToken cancellation)
        {
            return await _repository.Add(addressInput, cancellation);
        }

        public Seller ByUserId(int UserId, CancellationToken cancellation)
        {
            var allAdmin = _repository.GetAll(cancellation);

            foreach(var admin in allAdmin)
            {
                if(admin.UserId == UserId)
                    return admin;
            }

            return null;
        }

        public List<User> FindSellerInUser(CancellationToken cancellation)
        {
            var allUser = _userRepsitory.GetAll(cancellation);
            var allAdmin = _repository.GetAll(cancellation);
            var markUser = new List<User>();

            foreach(var user in allUser)
            {
                foreach(var admin in allAdmin)
                    if(user.Id == admin.UserId)
                        markUser.Add(user);
            }

            return markUser;
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

        public List<Seller> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public async Task<Seller> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        //public async Task<bool> Update(int Id, Seller addressInput, CancellationToken cancellation)
        //{
        //    return await _repository.Update(Id, addressInput, cancellation);
        //}
    }
}
