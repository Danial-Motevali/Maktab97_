using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    internal interface IPriceRepository
    {
        Task<bool> Add(PriceDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, PriceDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<PriceDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<PriceDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
