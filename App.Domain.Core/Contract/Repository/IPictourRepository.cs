using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IPictourRepository
    {
        Task<bool> Add(PictureDtoInput pictureInput, CancellationToken cancellation);

        Task<bool> Update(int Id, PictureDtoInput pictureInput, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<PictureDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<PictureDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
