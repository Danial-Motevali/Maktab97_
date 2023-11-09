using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
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
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public AdminRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<bool> Add(AdminMyDtoInput inputAddress, CancellationToken cancellation)
        {
            var address = await _db.MyAdmins.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address != null)
            {
                var newProduct = _mapper.Map<MyAdmin>(inputAddress);

                await _db.MyAdmins.AddAsync(newProduct, cancellation);
                await _db.SaveChangesAsync(cancellation);

                return true;
            }
            return false;
        }

        //public async Task<bool> Delete(int Id, CancellationToken cancellation)
        //{
        //    var address = await _db.Admins.FirstOrDefaultAsync(x => x.Id == Id);

        //    if (address != null)
        //    {
        //        address.IsDeleted = true;

        //        await _db.SaveChangesAsync(cancellation);

        //        return true;
        //    }
        //    return false;
        //}

        public async Task<List<AdminMyDtoOutput>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.MyAdmins.ToList();
            var result = addresses.Select(address => _mapper.Map<AdminMyDtoOutput>(address)).ToList();

            return result;
        }

        public async Task<AdminMyDtoOutput> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.MyAdmins.FirstOrDefault(x => x.Id == Id);
            var getAddress = _mapper.Map<AdminMyDtoOutput>(address);

            return getAddress;
        }

        //public async Task<bool> Update(int Id, AdminMyDtoInput inputAddress, CancellationToken cancellation)
        //{
        //    var address = _db.Admins.FirstOrDefault(x => x.Id == Id);

        //    if (address != null)
        //    {
        //        address.Id = inputAddress.Id;
        //        address.FirsName = inputAddress.FirsName;
        //        address.LastName = inputAddress.LastName;
        //        await _db.SaveChangesAsync(cancellation);
        //        return true;
        //    }

        //    return false;
        //}
    }
}
