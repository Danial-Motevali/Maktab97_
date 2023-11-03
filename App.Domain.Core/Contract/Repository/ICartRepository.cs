using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    internal interface ICartRepository
    {
        Task<bool> Add(CartDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, CartDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<CartDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<CartDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
