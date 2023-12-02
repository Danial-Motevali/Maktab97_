using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IShopRepository
    {
        Task<Shop> Add(Shop input, CancellationToken cancellation);

        Task<bool> Update(int Id, Shop input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Shop> GetById(int Id, CancellationToken cancellation);

        List<Shop> GetAll(CancellationToken cancellation);
    }
}
