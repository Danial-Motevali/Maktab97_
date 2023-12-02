using App.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IProductOrederService
    {
        Task<ProductOreder> Add(ProductOreder input, CancellationToken cancellation);

        Task<bool> Update(int Id, ProductOreder input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<ProductOreder> GetById(int Id, CancellationToken cancellation);

        Task<List<ProductOreder>> GetAll(CancellationToken cancellation);

        Task<List<ProductOreder>> GetByOrderId(int OrderId, CancellationToken cancellation);

        Task<List<ProductOreder>> GetByProductId(int ProductId, CancellationToken cancellation);
    }
}
