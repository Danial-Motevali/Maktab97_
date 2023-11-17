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
        public async Task<bool> Add(MyAdmin inputAddress, CancellationToken cancellation)
        {
            var address = await _db.MyAdmins.FirstOrDefaultAsync(x => x.Id == inputAddress.Id);

            if (address == null)
            {
                await _db.MyAdmins.AddAsync(inputAddress, cancellation);
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

        public  List<MyAdmin> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.MyAdmins.ToList();

            return addresses;
        }

        public async Task<MyAdmin> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.MyAdmins.FirstOrDefault(x => x.Id == Id);

            return address;
        }

        //public async Task<bool> Update(int Id, MyAdmin inputAddress, CancellationToken cancellation)
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
