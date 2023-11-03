using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    internal interface IProductPictureRepository
    {
        Task<bool> Add(ProductPictureDtoInput input, CancellationToken cancellation);

        Task<bool> Update(int Id, ProductPictureDtoInput input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<ProductPictureDtoOutput> GetById(int Id, CancellationToken cancellation);

        Task<List<ProductPictureDtoOutput>> GetAll(CancellationToken cancellation);
    }
}
