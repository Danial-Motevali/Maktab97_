using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IProductService
    {
        Task<bool> Add(ProductDtoInput productInput, CancellationToken cancellation);

        Task<bool> Update(int Id, ProductDtoInput productInput, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<ProductDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<ProductDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
