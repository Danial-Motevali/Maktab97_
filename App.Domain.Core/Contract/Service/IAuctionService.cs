using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IAuctionService
    {
        Task<Auction> Add(Auction input, CancellationToken cancellation);

        Task<bool> Update(int Id, Auction input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Auction> GetById(int Id, CancellationToken cancellation);

        List<Auction> GetAll(CancellationToken cancellation);

        Task<List<Auction>> GetBySellerId(int SellerId, CancellationToken cancellation);

        Task<List<Auction>> GetByParentId(int ParentId, CancellationToken cancellation);
    }
}
