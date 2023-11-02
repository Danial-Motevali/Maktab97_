using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IShopService
    {
        Task<bool> Add(ShopDtoInput shopInput, CancellationToken cancellation);

        Task<bool> Update(int Id, ShopDtoInput shopInput, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<ShopDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<ShopDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
