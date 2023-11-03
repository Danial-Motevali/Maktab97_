using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    internal interface IShopRepository
    {
        Task<bool> Add(ShopDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, ShopDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<ShopDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<ShopDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
