using App.Domain.Core.Entities;
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
        Task<bool> Add(Inventory input, CancellationToken cancellation);

        Task<bool> Update(int Id, Inventory input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Inventory> GetById(int Id, CancellationToken cancellation);

        Task<List<Inventory>> GetAll(CancellationToken cancellation);
    }
}
