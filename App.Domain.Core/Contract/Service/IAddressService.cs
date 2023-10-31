using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IAddressService
    {
        Task<bool> Add(AddressDtoInput addressInput);

        Task<bool> Update(int Id, AddressDtoInput addressInput);

        Task<bool> Delete(int Id);

        Task<AddressDtoOutPut> GetById(int Id);

        Task<List<AddressDtoOutPut>> GetAll();
    }
}
