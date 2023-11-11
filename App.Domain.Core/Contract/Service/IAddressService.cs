﻿using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IAddressService
    {
        Task<bool> Add(Address input, CancellationToken cancellation);

        Task<bool> Update(int Id, Address input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Address> GetById(int Id, CancellationToken cancellation);

        Task<List<Address>> GetAll(CancellationToken cancellation);
    }
}
