using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    internal interface IAddressRepository
    {
        Task<bool> Add(AddressDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, AddressDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<AddressDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<AddressDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
