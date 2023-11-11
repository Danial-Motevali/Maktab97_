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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(Comment commentInput, CancellationToken cancellation)
        {
            return await _repository.Add(commentInput, cancellation);
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

        public async Task<List<Comment>> GetAll(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }

        public async Task<Comment> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<bool> Update(int Id, Comment commentInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, commentInput, cancellation);
        }
    }
}
