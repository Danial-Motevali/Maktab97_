﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class PriceService : IPriceService
    {
        private readonly IPriceRepository _repository;
        public PriceService(IPriceRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(PriceDtoInput priceInput, CancellationToken cancellation)
        {
            return await _repository.Add(priceInput, cancellation);
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var cart = await _repository.GetById(Id, cancellation);
            if (cart != null)
            {
                await _repository.Delete(Id, cancellation);
                return true;
            }
            return false;
        }

        public async Task<List<PriceDtoOutput>> GetAll(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }

        public async Task<PriceDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<bool> Update(int Id, PriceDtoInput priceInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, priceInput, cancellation);
        }
    }
}
