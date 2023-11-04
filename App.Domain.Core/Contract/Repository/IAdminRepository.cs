using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IAdminRepository
    {
        Task<bool> Add(AdminDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, AdminDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<AdminDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<AdminDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
