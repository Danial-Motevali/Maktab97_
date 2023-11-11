using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface ICategoryRepository
    {
        Task<bool> Add(Category input, CancellationToken cancellation);

        Task<bool> Update(int Id, Category input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Category> GetById(int Id, CancellationToken cancellation);

        Task<List<Category>> GetAll(CancellationToken cancellation);
    }
}
