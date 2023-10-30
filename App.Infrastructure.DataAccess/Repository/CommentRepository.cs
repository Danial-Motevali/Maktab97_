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
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CommentRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(CommentDtoInput inputComment)
        {
            var comment = await _db.Comments.FirstOrDefaultAsync(x => x.Id == inputComment.Id);

            if (comment != null)
            {
                var newComment = _mapper.Map<Comment>(inputComment);

                await _db.AddAsync(newComment);
                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id)
        {
            var comment = await _db.Comments.FirstOrDefaultAsync(x => x.Id == Id);

            if (comment != null)
            {
                comment.IsDeleted = true;

                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<List<CommentDtoOutput>> GetAll()
        {
            var comments = _db.Comments.ToList();
            var result = comments.Select(comment => _mapper.Map<CommentDtoOutput>(comment)).ToList();

            return result;
        }

        public async Task<CommentDtoOutput> GetById(int Id)
        {
            var comment = _db.Comments.FirstOrDefault(x => x.Id == Id);
            var getComment = _mapper.Map<CommentDtoOutput>(comment);

            return getComment;
        }

        public async Task<bool> Update(int Id, CommentDtoInput inputComment)
        {
            var comment = _db.Comments.FirstOrDefault(x => x.Id == Id);

            if (comment != null)
            {
                comment.Id = inputComment.Id;
                comment.Title = inputComment.Title;
                comment.Description = inputComment.Description;

                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
