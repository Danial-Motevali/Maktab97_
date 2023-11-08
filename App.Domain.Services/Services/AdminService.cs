using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        public AdminService(IAdminRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Add(AdminMyDtoInput addressInput, CancellationToken cancellation)
        {
            return await _repository.Add(addressInput, cancellation);
        }

        //public async Task<bool> Delete(int Id, CancellationToken cancellation)
        //{
        //    var category = await _repository.GetById(Id, cancellation);
        //    if (category != null)
        //    {
        //        await _repository.Delete(Id, cancellation);
        //        return true;
        //    }
        //    return false;
        //}

        public async Task<List<AdminMyDtoOutput>> GetAll(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }

        public async Task<AdminMyDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            return await _repository.GetById(Id, cancellation);
        }

        //public async Task<bool> Update(int Id, AdminMyDtoInput addressInput, CancellationToken cancellation)
        //{
        //    return await _repository.Update(Id, addressInput, cancellation);
        //}
    }
}
