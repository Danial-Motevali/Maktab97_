using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface ICategoruService
    {
        Task<bool> Add(CategoryDtoInput categoryInput);

        Task<bool> Update(int Id, CategoryDtoInput categoryInput);

        Task<bool> Delete(int Id);

        Task<CategoryDtoOutput> GetById(int Id);

        Task<List<CategoryDtoOutput>> GetAll();
    }
}
