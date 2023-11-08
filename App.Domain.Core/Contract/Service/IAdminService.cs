﻿using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IAdminService
    {
        Task<bool> Add(AdminMyDtoInput input, CancellationToken cancellation);

        //Task<bool> Update(int Id, AdminMyDtoInput input, CancellationToken cancellation);

        //Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<AdminMyDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<AdminMyDtoOutput>> GetAll(CancellationToken cancellation);
    }
}