using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface ICategoryRepository
    {
        Task<bool> Add(CategoryDtoInput categoryInput, CancellationToken cancellation);

        Task<bool> Update(int Id, CategoryDtoInput categoryInput, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<CategoryDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<CategoryDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
