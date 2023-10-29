using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class PriceRepository : IPriceRepository
    {
        public Task<bool> Add(PictureDtoInput pictureInput)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PictureDtoOutput>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<PictureDtoOutput> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int Id, PictureDtoInput pictureInput)
        {
            throw new NotImplementedException();
        }
    }
}
