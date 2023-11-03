using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface IWageService
    {
        Task<bool> Add(WageDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, WageDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<WageDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<WageDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
