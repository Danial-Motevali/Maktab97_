﻿using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepsitory _repository;
        public UserServices(IUserRepsitory repository)
        {
            _repository = repository;
        }
        public async Task<User> Add(User pictureInput, CancellationToken cancellation)
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

        public List<User> GetAll(CancellationToken cancellation)
        {
            return  _repository.GetAll(cancellation);
        }

        public async Task<User> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        public async Task<bool> Update(int Id, User pictureInput, CancellationToken cancellation)
        {
            return await _repository.Update(Id, pictureInput, cancellation);
        }
    }
}
