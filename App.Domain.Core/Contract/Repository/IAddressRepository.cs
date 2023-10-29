using App.Domain.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Repository
{
    public interface IAddressRepository
    {
        Task<bool> Add(AddressDtoInput inputAddress);

        Task<bool> Update(int Id, AddressDtoInput inputAddress);

        Task<bool> Delete(int Id);

        Task<AddressDtoOutPut> GetById(int Id);

        Task<List<AddressDtoOutPut>> GetAll();
    }
}
