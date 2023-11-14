using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppServices
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IBuyerService _buyerService;
        private readonly ISellerService _sellerService;
        private readonly IUserServices _userServices;
        public AccountAppService(IBuyerService buyerService, ISellerService sellerService, IUserServices userServices)
        {
            _buyerService = buyerService;
            _sellerService = sellerService;
            _userServices = userServices;
        }

        public bool CreateBuyer(User User, CancellationToken cancellation)
        {
            var allUser = _userServices.GetAll(cancellation);

            foreach (var user in allUser)
            {
                if (user.UserName == User.UserName && user.FirstName == User.FirstName && user.LastName == User.LastName)
                {
                    var newBuyer = new Buyer
                    {
                        UserId = user.Id,
                    };

                    _buyerService.Add(newBuyer, cancellation);
                    return true;
                }
            }

            return false;
        }

        public bool CreateSeller(User User, CancellationToken cancellation)
        {
            var allUser = _userServices.GetAll(cancellation);

            foreach(var user in allUser)
            {
                if(user.UserName == User.UserName && user.FirstName == User.FirstName && user.LastName == User.LastName)
                {
                    var newSeller = new Seller
                    {
                        UserId = user.Id,
                    };

                    _sellerService.Add(newSeller, cancellation);
                    return true;
                }
            }

            return false;
        }
    }
}
