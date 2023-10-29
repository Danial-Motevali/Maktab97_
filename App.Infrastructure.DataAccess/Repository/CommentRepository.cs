using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public Task<bool> Add(CommentDtoInput commentInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentDtoOutput>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CommentDtoOutput> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int Id, CommentDtoInput commentInput)
        {
            throw new NotImplementedException();
        }
    }
}
