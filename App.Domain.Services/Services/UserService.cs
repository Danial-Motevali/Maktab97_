using App.Domain.Core.Contract.Service;
using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserService _repository;
        public UserService(IUserService repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(UserDtoInput userInput)
        {
            return await _repository.Add(userInput);
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

        public async Task<List<UserDtoOutput>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<UserDtoOutput> GetById(int Id)
        {
            return await _repository.GetById(Id);
        }

        public async Task<bool> Update(int Id, UserDtoInput userInput)
        {
            return await _repository.Update(Id, userInput);
        }
    }
}
