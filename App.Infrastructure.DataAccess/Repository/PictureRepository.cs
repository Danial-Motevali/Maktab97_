using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.DTOs;
using App.Domain.Core.Models.Entities;
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
    public class PictureRepository : IPictourRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public PictureRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(PictureDtoInput inputPicture, CancellationToken cancellation)
        {
            var pictoure = await _db.Pictoures.FirstOrDefaultAsync(x => x.Id == inputPicture.Id);

            if (pictoure != null)
            {
                var newPicture = _mapper.Map<Pictoure>(inputPicture);

                await _db.Pictoures.AddAsync(newPicture, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var pictoure = await _db.Pictoures.FirstOrDefaultAsync(x => x.Id == Id);

            if (pictoure != null)
            {
                pictoure.IsDeleted = true;

                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        public async Task<List<PictureDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var pictoures = _db.Pictoures.ToList();
            var result = pictoures.Select(Pictoure => _mapper.Map<PictureDtoOutput>(Pictoure)).ToList();

            return result;
        }

        public async Task<PictureDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var pictoures = _db.Pictoures.FirstOrDefault(x => x.Id == Id);
            var getPictour = _mapper.Map<PictureDtoOutput>(pictoures);

            return getPictour;
        }

        public async Task<bool> Update(int Id, PictureDtoInput inputPicture, CancellationToken cancellation)
        {
            var pictoures = _db.Pictoures.FirstOrDefault(x => x.Id == Id);

            if (pictoures != null)
            {
                pictoures.Id = inputPicture.Id;
                pictoures.Url = inputPicture.Url;

                await _db.SaveChangesAsync(cancellation);
                return true;
            }

            return false;
        }
    }
}
