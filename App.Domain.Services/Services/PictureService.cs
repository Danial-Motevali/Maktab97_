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
        private readonly IPictureService _repository;
        public PictureService(IPictureService repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(PictureDtoInput pictureInput)
        {
            return await _repository.Add(pictureInput);
        }

        public async Task<bool> Delete(int Id)
        {
            var cart = await _repository.GetById(Id);
            if (cart != null)
            {
                await _repository.Delete(Id);
                return true;
            }
            return false;
        }

        public async Task<List<PictureDtoOutput>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<PictureDtoOutput> GetById(int Id)
        {
            return await _repository.GetById(Id);
        }

        public async Task<bool> Update(int Id, PictureDtoInput pictureInput)
        {
            return await _repository.Update(Id, pictureInput);
        }
    }
}
