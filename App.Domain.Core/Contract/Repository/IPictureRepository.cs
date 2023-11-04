using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IPictureRepository
    {
        Task<bool> Add(PictureDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, PictureDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<PictureDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<PictureDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
