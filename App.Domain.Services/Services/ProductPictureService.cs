using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class ProductPictureService : IProductPictureService
    {
        private readonly IProductPicture _picturePictureRepository;
        public ProductPictureService(IProductPicture productPicture)
        {
            _picturePictureRepository = productPicture;

        }
        public List<ProductPicture> GetByProducId(int ProductId, CancellationToken cancellation)
        {
            var allProductPicture = _picturePictureRepository.GetAll(cancellation);
            var markProduct = new List<ProductPicture>();

            foreach (var item in allProductPicture)
            {
                if (item.ProductId == ProductId)
                    markProduct.Add(item);
            }

            return markProduct;
        }

        public List<ProductPicture> GetByPictureId(int PictureId, CancellationToken cancellation)
        {
            var allProductPicture = _picturePictureRepository.GetAll(cancellation);
            var markProduct = new List<ProductPicture>();

            foreach (var item in allProductPicture)
            {
                if (item.PictureId == PictureId)
                    markProduct.Add(item);
            }

            return markProduct;
        }

        public List<ProductPicture> GetAll(CancellationToken cancellation)
        {
            return _picturePictureRepository.GetAll(cancellation);
        }

        public async Task<ProductPicture> Add(ProductPicture input, CancellationToken cancellation)
        {
            return await _picturePictureRepository.Add(input, cancellation);
        }
    }
}
