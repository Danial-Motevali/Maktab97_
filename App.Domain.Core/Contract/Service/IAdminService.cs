﻿using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IAdminService
    {
        Task<MyAdmin> Add(MyAdmin input, CancellationToken cancellation);

        //Task<bool> Update(int Id, MyAdmin input, CancellationToken cancellation);

        //Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<MyAdmin> GetById(int Id, CancellationToken cancellation);

        List<MyAdmin> GetAll(CancellationToken cancellation);

        MyAdmin GetByUserId(int UserId, CancellationToken cancellation);

        List<User> FindAdminInUser(CancellationToken cancellation);

        //Task<List<Product>> FindProductsBySellerIs(int Id, CancellationToken cancellation);
    }
}
