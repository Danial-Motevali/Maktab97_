using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Task<bool> Add(ProductDtoInput productInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDtoOutput>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDtoOutput> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int Id, ProductDtoInput productInput)
        {
            throw new NotImplementedException();
        }
    }
}
