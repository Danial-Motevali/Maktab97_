using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class WageRepository : IWageRepository
    {
        public Task<bool> Add(WageDtoInput wageInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<WageDtoOutput>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<WageDtoOutput> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int Id, WageDtoInput wageInput)
        {
            throw new NotImplementedException();
        }
    }
}
