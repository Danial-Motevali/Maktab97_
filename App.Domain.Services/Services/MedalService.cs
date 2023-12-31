﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class MedalService : IMedalService
    {
        private readonly IMedalRepository _repository;
        public MedalService(IMedalRepository repository)
        {
            _repository = repository;
        }

        public async Task<Medal> Add(Medal addressInput, CancellationToken cancellation)
        {
            return await _repository.Add(addressInput, cancellation);
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var category = await _repository.GetById(Id, cancellation);
            if (category != null)
            {
                await _repository.Delete(Id, cancellation);
                return true;
            }
            return false;
        }

        public  List<Medal> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public async Task<Medal> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public List<Medal> GetBySellerId(int sellerId, CancellationToken cancellation)
        {
            var allMedal = _repository.GetAll(cancellation);
            var markMedal = new List<Medal>();

            foreach (var medal in allMedal) 
            {
                if(medal.SellerId == sellerId)
                    markMedal.Add(medal);
            }

            return markMedal;
        }

        public async Task<bool> Update(int Id, Medal addressInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, addressInput, cancellation);
        }
    }
}
