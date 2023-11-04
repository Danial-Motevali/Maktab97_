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
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CommentRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(CommentDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Comments.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                var newProduct = _mapper.Map<Comment>(inputAddress);

                await _db.Comments.AddAsync(newProduct, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Comments.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<CommentDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Comments.ToList();
            var result = addresses.Select(address => _mapper.Map<CommentDtoOutput>(address)).ToList();

            return result;
        }

        public async Task<CommentDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Comments.FirstOrDefault(x => x.Id == Id);
            var getAddress = _mapper.Map<CommentDtoOutput>(address);

            return getAddress;
        }

        public async Task<bool> Update(int Id, CommentDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = _db.Comments.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.Title = inputAddress.Title;
                address.Description = inputAddress.Description;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
