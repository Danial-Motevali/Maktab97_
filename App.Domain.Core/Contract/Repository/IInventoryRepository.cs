using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IInventoryRepository
    {
        Task<bool> Add(InventoryDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, InventoryDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<InventoryDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<InventoryDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
