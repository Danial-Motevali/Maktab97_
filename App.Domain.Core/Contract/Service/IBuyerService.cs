﻿using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IBuyerService
    {
        Task<Buyer> Add(Buyer input, CancellationToken cancellation);

        Task<bool> Update(int Id, Buyer input, CancellationToken cancellation);

        //Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Buyer> GetById(int Id, CancellationToken cancellation);

        List<Buyer> GetAll(CancellationToken cancellation);

        Buyer ByUserId(int UserId, CancellationToken cancellation);

        List<User> FindBuyerInUser(CancellationToken cancellation);
    }
}
