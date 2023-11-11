using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface ICommentRepository
    {
        Task<bool> Add(Comment input, CancellationToken cancellation);

        Task<bool> Update(int Id, Comment input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Comment> GetById(int Id, CancellationToken cancellation);

        Task<List<Comment>> GetAll(CancellationToken cancellation);
    }
}
