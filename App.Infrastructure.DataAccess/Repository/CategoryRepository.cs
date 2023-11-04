using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
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
        public async Task<bool> Add(CategoryDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Categories.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                var newProduct = _mapper.Map<Category>(inputAddress);

                await _db.Categories.AddAsync(newProduct, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Categories.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<CategoryDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Categories.ToList();
            var result = addresses.Select(address => _mapper.Map<CategoryDtoOutput>(address)).ToList();

            return result;
        }

        public async Task<CategoryDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Categories.FirstOrDefault(x => x.Id == Id);
            var getAddress = _mapper.Map<CategoryDtoOutput>(address);

            return getAddress;
        }

        public async Task<bool> Update(int Id, CategoryDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = _db.Categories.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.Title = inputAddress.Title;
                address.ParentId = inputAddress.ParentId;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
