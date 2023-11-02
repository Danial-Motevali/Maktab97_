using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IAddressRepository
    {
        Task<bool> Add(AddressDtoInput inputAddress, CancellationToken cancellation);

        Task<bool> Update(int Id, AddressDtoInput inputAddress, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<AddressDtoOutPut> GetById(int Id, CancellationToken cancellation);

        Task<List<AddressDtoOutPut>> GetAll(CancellationToken cancellation);
    }
}
