﻿using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface ISellerRepository
    {
        Task<Seller> Add(Seller input, CancellationToken cancellation);

        //Task<bool> Update(int Id, Seller input, CancellationToken cancellation);

        //Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Seller> GetById(int Id, CancellationToken cancellation);

        List<Seller> GetAll(CancellationToken cancellation);
    }
}
