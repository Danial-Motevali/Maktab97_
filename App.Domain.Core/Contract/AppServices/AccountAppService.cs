using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.AppServices
{
    public interface IAccountAppService
    {
        Task<bool> CreateBuyer(User User, CancellationToken cancellation);
        Task<bool> CreateSeller(User User, CancellationToken cancellation);
    }
}
