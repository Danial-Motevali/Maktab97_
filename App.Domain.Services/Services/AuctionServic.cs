using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class AuctionServic : IAuctionService
    {
        private readonly IAuctionRepository _repository;
        public AuctionServic(IAuctionRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(AuctionDtoInput auctionInput, CancellationToken cancellation)
        {
            return await _repository.Add(auctionInput, cancellation);
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var auction = await _repository.GetById(Id, cancellation);
            if (auction != null)
            {
                await _repository.Delete(Id, cancellation);
                return true;
            }
            return false;
        }

        public async Task<List<AuctionDtoOutput>> GetAll(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }

        public async Task<AuctionDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<bool> Update(int Id, AuctionDtoInput auctionInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, auctionInput, cancellation);
        }
    }
}
