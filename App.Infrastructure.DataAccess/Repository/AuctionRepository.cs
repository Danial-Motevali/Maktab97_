using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class AuctionRepository : IAuctionRepository
    {
        public Task<bool> Add(AuctionDtoInput auctionInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AuctionDtoOutput>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuctionDtoOutput> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int Id, AuctionDtoInput auctionInput)
        {
            throw new NotImplementedException();
        }
    }
}
