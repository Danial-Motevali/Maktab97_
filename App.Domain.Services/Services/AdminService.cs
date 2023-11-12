﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        private readonly ISellerRepository _sellerRepository;
        public AdminService(IAdminRepository repository, ISellerRepository sellerRepository)
        {
            _repository = repository;
            _sellerRepository = sellerRepository;
        }
        public async Task<bool> Add(MyAdmin addressInput, CancellationToken cancellation)
        {
            return await _repository.Add(addressInput, cancellation);
        }

        //public Task<List<Product>> FindProductsBySellerIs(int sellerId, CancellationToken cancellation)
        //{
        //     _sellerRepository.GetById(sellerId, cancellation);
        //}

        //public async Task<bool> Delete(int Id, CancellationToken cancellation)
        //{
        //    var category = await _repository.GetById(Id, cancellation);
        //    if (category != null)
        //    {
        //        await _repository.Delete(Id, cancellation);
        //        return true;
        //    }
        //    return false;
        //}

        public List<MyAdmin> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public async Task<MyAdmin> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        //public async Task<bool> Update(int Id, MyAdmin addressInput, CancellationToken cancellation)
        //{
        //    return await _repository.Update(Id, addressInput, cancellation);
        //}
    }
}
