using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Infrastructure.Data.EF;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class PictureRepository : IPictureRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public PictureRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<Picture> Add(Picture inputAddress, CancellationToken cancellation)
        {
            var address = await _db.Pictures.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address == null)
            {
                await _db.Pictures.AddAsync(inputAddress, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return inputAddress;
            }
            return address;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var address = await _db.Pictures.FirstOrDefaultAsync(x => x.Id == Id);

            if (address != null)
            {
                address.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public  List<Picture> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.Pictures.ToList();
            var mark = new List<Picture>();

            mark = addresses.Where(x => x.IsDeleted == false).ToList();

            return mark;
        }

        public async Task<Picture> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.Pictures.FirstOrDefault(x => x.Id == Id && x.IsDeleted == false);

            return address;
        }

        public async Task<bool> Update(int Id, Picture inputAddress, CancellationToken cancellation)
        {
            var address = _db.Pictures.FirstOrDefault(x => x.Id == Id);

            if (address != null)
            {
                address.Id = inputAddress.Id;
                address.Url = inputAddress.Url;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
