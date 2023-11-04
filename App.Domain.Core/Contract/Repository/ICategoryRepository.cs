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
        Task<bool> Add(CategoryDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, CategoryDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<CategoryDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<CategoryDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
