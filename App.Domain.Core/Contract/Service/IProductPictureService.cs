using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IProductPictureService
    {
        List<ProductPicture> GetByProducId(int ProductId, CancellationToken cancellation);
        List<ProductPicture> GetByPictureId(int PictureId, CancellationToken cancellation);
        List<ProductPicture> GetAll(CancellationToken cancellation);
        Task<ProductPicture> Add(ProductPicture input, CancellationToken cancellation);
       // List<Product> AllProductctByPictureId(int Picturid, CancellationToken cancellation);
        //List<Product> AllProdutctByProductId(int Picturid, CancellationToken cancellation);
    }
}
