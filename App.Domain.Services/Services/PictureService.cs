using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictourRepository _repository;
        public PictureService(IPictourRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(PictureDtoInput pictureInput, CancellationToken cancellation)
        {
            return await _repository.Add(pictureInput, cancellation);
        }

        public async Task<bool> Delete(int Id, CancellationToken cancellation)
        {
            var cart = await _repository.GetById(Id, cancellation);
            if (cart != null)
            {
                await _repository.Delete(Id, cancellation);
                return true;
            }
            return false;
        }

        public async Task<List<PictureDtoOutput>> GetAll(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }

        public async Task<PictureDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<bool> Update(int Id, PictureDtoInput pictureInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, pictureInput, cancellation);
        }
    }
}
