using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<bool> Add(CategoryDtoInput categoryInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryDtoOutput>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDtoOutput> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int Id, CategoryDtoInput categoryInput)
        {
            throw new NotImplementedException();
        }
    }
}
