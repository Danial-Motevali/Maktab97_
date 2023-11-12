using App.Domain.Core.Entities;
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
        Task<bool> Add(Product input, CancellationToken cancellation);

        Task<bool> Update(int Id, Product input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Product> GetById(int? Id, CancellationToken cancellation);

        List<Product> GetAll(CancellationToken cancellation);
    }
}
