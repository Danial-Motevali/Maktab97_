using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IAuctionRepository
    {
        Task<bool> Add(Auction input, CancellationToken cancellation);

        Task<bool> Update(int Id, Auction input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Auction> GetById(int Id, CancellationToken cancellation);

        Task<List<Auction>> GetAll(CancellationToken cancellation);
    }
}
