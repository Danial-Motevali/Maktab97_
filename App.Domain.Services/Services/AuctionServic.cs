using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class AuctionServic : IAuctionRepository
    {
        private readonly IAuctionRepository _repository;
        public AuctionServic(IAuctionRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(AuctionDtoInput auctionInput)
        {
            return await _repository.Add(auctionInput);
        }

        public async Task<bool> Delete(int Id)
        {
            var auction = await _repository.GetById(Id);
            if (auction != null)
            {
                await _repository.Delete(Id);
                return true;
            }
            return false;
        }

        public async Task<List<AuctionDtoOutput>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<AuctionDtoOutput> GetById(int Id)
        {
            return await _repository.GetById(Id);
        }

        public async Task<bool> Update(int Id, AuctionDtoInput auctionInput)
        {
            return await _repository.Update(Id, auctionInput);
        }
    }
}
