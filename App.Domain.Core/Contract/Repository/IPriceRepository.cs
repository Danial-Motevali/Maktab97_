using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IPriceRepository
    {
        Task<bool> Add(PictureDtoInput pictureInput);

        Task<bool> Update(int Id, PictureDtoInput pictureInput);

        Task<bool> Delete(int Id);

        Task<PictureDtoOutput> GetById(int Id);

        Task<List<PictureDtoOutput>> GetAll();
    }
}
