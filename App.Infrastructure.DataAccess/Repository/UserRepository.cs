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
    public class UserRepository : IUSerRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(UserDtoInput inputUser)
        {
            var users = await _db.Users.FirstOrDefaultAsync(x => x.Id == inputUser.Id);

            if (users != null)
            {
                var newUser = _mapper.Map<User>(inputUser);

                await _db.AddAsync(newUser);
                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int Id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == Id);

            if (user != null)
            {
                user.IsDeleted = true;

                await _db.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<List<UserDtoOutput>> GetAll()
        {
            var users = _db.Users.ToList();
            var result = users.Select(user => _mapper.Map<UserDtoOutput>(user)).ToList();

            return result;
        }

        public async Task<UserDtoOutput> GetById(int Id)
        {
            var users = _db.Users.FirstOrDefault(x => x.Id == Id);
            var getUser = _mapper.Map<UserDtoOutput>(users);

            return getUser;
        }

        public async Task<bool> Update(int Id, UserDtoInput inputUser)
        {
            var user = _db.Users.FirstOrDefault(x => x.Id == Id);

            if (user != null)
            {
                user.Id = inputUser.Id;
                user.FirstName = inputUser.FirstName;
                user.LastName = inputUser.LastName;
                user.UserName = inputUser.UserName;
                user.Email = inputUser.Email;
                user.PassWord = inputUser.PassWord;
                user.IsDeleted = inputUser.IsDeleted;

                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
