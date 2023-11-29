using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Models.Identity.Entites;
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
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public RoleRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public List<IdentityRole<int>> GetAll(CancellationToken cancellation)
        {
            var addresses = _db.IdRoles.ToList();

            return addresses;
        }

        public IdentityRole<int> GetById(int Id, CancellationToken cancellation)
        {
            var address = _db.IdRoles.FirstOrDefault(x => x.Id == Id);

            return address;
        }
    }
}
