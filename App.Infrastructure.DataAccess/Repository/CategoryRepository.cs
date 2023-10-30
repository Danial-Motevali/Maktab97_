using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using App.Domain.Core.Models.Entities;
using App.Infrastructure.Data.EF;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(CategoryDtoInput inputCategory)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == inputCategory.Id);

            if (category != null)
            {
                var newCategory = _mapper.Map<Category>(inputCategory);

                await _db.AddAsync(newCategory);
                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(x => x.Id == Id);

            if (category != null)
            {
                category.IsDeleted = true;

                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<List<CategoryDtoOutput>> GetAll()
        {
            var categorys = _db.Addresses.ToList();
            var result = categorys.Select(category => _mapper.Map<CategoryDtoOutput>(category)).ToList();

            return result;
        }

        public async Task<CategoryDtoOutput> GetById(int Id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == Id);
            var getCategory = _mapper.Map<CategoryDtoOutput>(category);

            return getCategory;
        }

        public async Task<bool> Update(int Id, CategoryDtoInput inputCategory)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == Id);

            if (category != null)
            {
                category.Id = inputCategory.Id;
                category.Title = inputCategory.Title;
                category.ParentId = inputCategory.ParentId;

                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
