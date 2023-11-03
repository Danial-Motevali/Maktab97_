using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Services
{
    public interface ISellerService
    {
        Task<bool> Add(SellerDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, SellerDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<SellerDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<SellerDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
