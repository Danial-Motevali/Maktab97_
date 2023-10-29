using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class CartRepository : ICartRepository
    {
        public Task<bool> Add(CartDtoInput CartInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartDtoOutput>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CartDtoOutput> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int Id, CartDtoInput CartInput)
        {
            throw new NotImplementedException();
        }
    }
}
