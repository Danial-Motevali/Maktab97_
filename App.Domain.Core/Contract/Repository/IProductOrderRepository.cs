using App.Domain.Core.Entities;
using App.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IProductOrderRepository
    {
        Task<ProductOreder> Add(ProductOreder input, CancellationToken cancellation);

        Task<bool> Update(int Id, ProductOreder input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<ProductOreder> GetById(int Id, CancellationToken cancellation);

        Task<List<ProductOreder>> GetAll(CancellationToken cancellation);

        Task<List<ProductOreder>> GetOrderId(int OrderId, CancellationToken cancellation);

        Task<List<ProductOreder>> GetProductId(int ProductId, CancellationToken cancellation);
    }
}
