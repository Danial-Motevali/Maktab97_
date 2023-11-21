using App.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IProductPicture
    {
        List<ProductPicture> GetAll(CancellationToken cancellation);

        ProductPicture GetById(int Id, CancellationToken cancellation);

        Task<bool> Add(ProductPicture inpur, CancellationToken cancellation);
    }
}
