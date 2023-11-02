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
    public class UserService : IUserService
    {
        private readonly IUSerRepository _repository;
        public UserService(IUSerRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(UserDtoInput userInput, CancellationToken cancellation)
        {
            return await _repository.Add(userInput, cancellation);
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

        public async Task<List<UserDtoOutput>> GetAll(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }

        public async Task<UserDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<bool> Update(int Id, UserDtoInput userInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, userInput, cancellation);
        }
    }
}
