using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IWageRepository
    {
        Task<bool> Add(WageDtoInput wageInput);

        Task<bool> Update(int Id, WageDtoInput wageInput);

        Task<bool> Delete(int Id);

        Task<WageDtoOutput> GetById(int Id);

        Task<List<WageDtoOutput>> GetAll();
    }
}
