using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class ShopRepository : IShopRepository
    {
        public Task<bool> Add(ShopDtoInput shopInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShopDtoOutput>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ShopDtoOutput> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int Id, ShopDtoInput shopInput)
        {
            throw new NotImplementedException();
        }
    }
}
