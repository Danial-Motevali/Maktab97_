using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface ICartRepository
    {
        Task<Cart> Add(Cart input, CancellationToken cancellation);

        Task<bool> Update(int Id, Cart input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Cart> GetById(int Id, CancellationToken cancellation);

        List<Cart> GetAll(CancellationToken cancellation);
    }
}
