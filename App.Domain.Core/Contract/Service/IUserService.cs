using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IUserService
    {
        Task<bool> Add(UserDtoInput userInput);

        Task<bool> Update(int Id, UserDtoInput userInput);

        Task<bool> Delete(int Id);

        Task<UserDtoOutput> GetById(int Id);

        Task<List<UserDtoOutput>> GetAll();
    }
}
