using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IUSerRepository
    {
        Task<bool> Add(UserDtoInput userInput, CancellationToken cancellation);

        Task<bool> Update(int Id, UserDtoInput userInput, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<UserDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<UserDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
