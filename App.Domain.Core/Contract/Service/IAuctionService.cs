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
        Task<bool> Add(AuctionDtoInput auctionInput);

        Task<bool> Update(int Id, AuctionDtoInput auctionInput);

        Task<bool> Delete(int Id);

        Task<AuctionDtoOutput> GetById(int Id);

        Task<List<AuctionDtoOutput>> GetAll();
    }
}
