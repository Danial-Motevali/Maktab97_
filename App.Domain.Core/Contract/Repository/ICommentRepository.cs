using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    internal interface ICommentRepository
    {
        Task<bool> Add(CommentDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, CommentDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<CommentDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<CommentDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
