using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities;
using App.Infrastructure.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class ProductPictureRepository : IProductPicture
    {
        private readonly ApplicationDbContext _db;

        public ProductPictureRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<ProductPicture> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.ProductPictures.ToList();

            return addresses;
        }

        public ProductPicture GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.ProductPictures.FirstOrDefault(x => x.Id == Id);

            return address;
        }
    }
}
