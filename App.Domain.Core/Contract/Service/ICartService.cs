using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface ICartService
    {
        Task<bool> Add(CartDtoInput cartInput);

        Task<bool> Update(int Id, CartDtoInput cartInput);

        Task<bool> Delete(int Id);

        Task<CartDtoOutput> GetById(int Id);

        Task<List<CartDtoOutput>> GetAll();
    }
}
