using App.Domain.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IInventoryOrederService
    {
        Task<InventoryOreder> Add(InventoryOreder input, CancellationToken cancellation);

        Task<bool> Update(int Id, InventoryOreder input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<InventoryOreder> GetById(int Id, CancellationToken cancellation);

        Task<List<InventoryOreder>> GetAll(CancellationToken cancellation);

        Task<List<InventoryOreder>> GetByOrderId(int OrderId, CancellationToken cancellation);

        Task<List<InventoryOreder>> GetInventoryId(int ProductId, CancellationToken cancellation);
    }
}
