using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface ICommentService
    {
        Task<bool> Add(CommentDtoInput commentInput, CancellationToken cancellation);

        Task<bool> Update(int Id, CommentDtoInput commentInput, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<CommentDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<CommentDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
