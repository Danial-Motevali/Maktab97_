using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IMedalService
    {
        Task<bool> Add(Medal input, CancellationToken cancellation);

        Task<bool> Update(int Id, Medal input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Medal> GetById(int Id, CancellationToken cancellation);

        List<Medal> GetAll(CancellationToken cancellation);

        List<Medal> GetBySellerId(int sellerId, CancellationToken cancellation);
    }
}
