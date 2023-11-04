using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IMedalRepository
    {
        Task<bool> Add(MedalDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, MedalDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<MedalDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<MedalDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
