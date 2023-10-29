using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using App.Infrastructure.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _db;
        public AddressRepository(ApplicationDbContext db)
        {
            _db = db;   
        }
        public Task<bool> Add(AddressDtoInput inputAddress)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AddressDtoOutPut>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AddressDtoOutPut> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int Id, AddressDtoInput inputAddress)
        {
            throw new NotImplementedException();
        }
    }
}
