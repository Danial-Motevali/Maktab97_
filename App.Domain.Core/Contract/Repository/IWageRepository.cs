using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IWageRepository
    {
        Task<bool> Add(WageDtoInput wageInput, CancellationToken cancellation);

        Task<bool> Update(int Id, WageDtoInput wageInput, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<WageDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<WageDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
