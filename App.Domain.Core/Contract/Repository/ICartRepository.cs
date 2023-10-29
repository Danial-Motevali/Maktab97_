using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface ICartRepository
    {
        Task<bool> Add(CartDtoInput CartInput);

        Task<bool> Update(int Id, CartDtoInput CartInput);

        Task<bool> Delete(int Id);

        Task<CartDtoOutput> GetById(int Id);

        Task<List<CartDtoOutput>> GetAll();
    }
}
