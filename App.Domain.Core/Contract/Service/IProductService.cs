using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    internal interface IProductService
    {
        Task<bool> Add(ProductDtoInput productInput);

        Task<bool> Update(int Id, ProductDtoInput productInput);

        Task<bool> Delete(int Id);

        Task<ProductDtoOutput> GetById(int Id);

        Task<List<ProductDtoOutput>> GetAll();
    }
}
