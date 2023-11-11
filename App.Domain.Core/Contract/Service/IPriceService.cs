using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IPriceService
    {
        Task<bool> Add(Price input, CancellationToken cancellation);

        Task<bool> Update(int Id, Price input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Price> GetById(int Id, CancellationToken cancellation);

        Task<List<Price>> GetAll(CancellationToken cancellation);
    }
}
