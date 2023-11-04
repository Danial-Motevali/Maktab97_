using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IProductRepository
    {
        Task<bool> Add(ProductDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, ProductDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<ProductDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<ProductDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
