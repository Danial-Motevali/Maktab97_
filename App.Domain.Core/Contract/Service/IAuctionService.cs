using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IAuctionService
    {
        Task<bool> Add(AuctionDtoInput auctionInput, CancellationToken cancellation);

        Task<bool> Update(int Id, AuctionDtoInput auctionInput, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<AuctionDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<AuctionDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
