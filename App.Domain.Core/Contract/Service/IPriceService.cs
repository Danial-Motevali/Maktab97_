using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IPriceService
    {
        Task<bool> Add(PriceDtoInput priceInput);

        Task<bool> Update(int Id, PriceDtoInput priceInput);

        Task<bool> Delete(int Id);

        Task<PriceDtoOutput> GetById(int Id);

        Task<List<PriceDtoOutput>> GetAll();
    }
}
