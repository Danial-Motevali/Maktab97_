using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
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
        public async Task<Comment> Add(Comment commentInput, CancellationToken cancellation)
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

        public  List<Comment> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public List<Comment> GetAllByBuyerId(int BuyerId, CancellationToken cancellation)
        {
            var allcomments = _repository.GetAll(cancellation);
            var markComments = new List<Comment>();

            foreach(var comment in allcomments)
            {
                if(comment.BuyerId == BuyerId)
                    markComments.Add(comment);
            }

            return markComments;
        }

        public List<Comment> GetAllByInventoryId(int InventoryId, CancellationToken cancellation)
        {
            var allcomments = _repository.GetAll(cancellation);
            var markComments = new List<Comment>();

            foreach (var comment in allcomments)
            {
                if (comment.InventoryId == InventoryId)
                    markComments.Add(comment);
            }

            return markComments;
        }

        public List<Comment> GetByBuyerId(int BuyerId, CancellationToken cancellation)
        {
            var allComment = _repository.GetAll(cancellation);
            var markComments = new List<Comment>();

            foreach(var comment in allComment)
            {
                if(comment.BuyerId == BuyerId)
                    markComments.Add(comment);
            }

            return markComments;
        }

        public async Task<Comment> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public List<Comment> GetByInventoryId(int InventoryId, CancellationToken cancellation)
        {
            var allComment = _repository.GetAll(cancellation);
            var markComments = new List<Comment>();

            foreach (var comment in allComment)
            {
                if (comment.InventoryId == InventoryId)
                    markComments.Add(comment);
            }

            return markComments;
        }

        public async Task<bool> Update(int Id, Comment commentInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, commentInput, cancellation);
        }
    }
}
