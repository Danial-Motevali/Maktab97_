using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    internal interface ICommentService
    {
        Task<bool> Add(CommentDtoInput commentInput);

        Task<bool> Update(int Id, CommentDtoInput commentInput);

        Task<bool> Delete(int Id);

        Task<CommentDtoOutput> GetById(int Id);

        Task<List<CommentDtoOutput>> GetAll();
    }
}
