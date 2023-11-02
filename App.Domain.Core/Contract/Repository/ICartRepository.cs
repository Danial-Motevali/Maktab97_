using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface ICartRepository
    {
        Task<bool> Add(CartDtoInput CartInput, CancellationToken cancellation);

        Task<bool> Update(int Id, CartDtoInput CartInput, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<CartDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<CartDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
