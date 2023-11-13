using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(Category categoryInput, CancellationToken cancellation)
        {
            return await _repository.Add(categoryInput, cancellation);
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var cart = await _repository.GetById(Id, cancellation);
            if (cart != null)
            {
                await _repository.Delete(Id, cancellation);
                return true;
            }
            return false;
        }

        public  List<Category> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public async Task<Category> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public List<Category> GetByPatentId(int ParentId, CancellationToken cancellation)
        {
            var allCategory = _repository.GetAll(cancellation);
            var parentCategory = new List<Category>();

            foreach (var category in allCategory)
            {
                if(category.ParentId == ParentId)
                    parentCategory.Add(category);
            }

            return parentCategory;
        }

        public async Task<bool> Update(int Id, Category categoryInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, categoryInput, cancellation);
        }
    }
}
