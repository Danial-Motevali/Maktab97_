using App.Domain.Core.Contract.Repository;
using App.Infrastructure.Data.EF;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public UserRoleRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public List<IdentityUserRole<int>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.UserRoles.ToList();

            return addresses;
        }

        //public IdentityUserRole<int> GetById(int Id, CancellationToken cancellation)
        //{
        //    var address = _db.UserRoles.FirstOrDefault(x => x.RoleId == Id);

        //    return address;
        //}
    }
}
