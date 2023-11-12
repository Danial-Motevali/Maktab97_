using App.Domain.Core.Entities;
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
        Task<bool> Add(Picture input, CancellationToken cancellation);

        Task<bool> Update(int Id, Picture input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<Picture> GetById(int Id, CancellationToken cancellation);

        List<Picture> GetAll(CancellationToken cancellation);
    }
}
