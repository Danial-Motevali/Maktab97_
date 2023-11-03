using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    internal interface IBuyerRepository
    {
        Task<bool> Add(BuyerDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, BuyerDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<BuyerDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<BuyerDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
