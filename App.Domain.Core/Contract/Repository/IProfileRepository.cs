using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IProfileRepository
    {
        Task<bool> Add(ProfileDtoInput profileInput);

        Task<bool> Update(int Id, ProfileDtoInput profileInput);

        Task<bool> Delete(int Id);

        Task<ProfileDtoOutput> GetById(int Id);

        Task<List<ProfileDtoOutput>> GetAll();
    }
}
