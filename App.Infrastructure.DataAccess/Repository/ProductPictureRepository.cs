using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities;
using App.Infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;
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

        public async Task<ProductPicture> Add(ProductPicture inpur, CancellationToken cancellation)
        {
            var address = await _db.ProductPictures.FirstOrDefaultAsync(x => x.Id == inpur.Id);

            if (address == null)
            {
                await _db.ProductPictures.AddAsync(inpur, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return inpur;
            }
            return address;
        }

        public List<ProductPicture> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.ProductPictures.ToList();
            var mark = new List<ProductPicture>();

            mark = addresses.Where(x => x.IsDeleted == false).ToList();

            return mark;
        }

        public ProductPicture GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.ProductPictures.FirstOrDefault(x => x.Id == Id && x.IsDeleted == false);

            return address;
        }
    }
}
