﻿using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface ICategoryService
    {
        Task<Category> Add(Category input, CancellationToken cancellation);

        Task<bool> Update(int Id, Category input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Category> GetById(int Id, CancellationToken cancellation);

        List<Category> GetAll(CancellationToken cancellation);

        List<Category> GetByPatentId(int ParentId, CancellationToken cancellation);
    }
}
