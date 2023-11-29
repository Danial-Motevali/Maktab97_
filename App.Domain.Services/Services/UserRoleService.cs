using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Models.Identity.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _repository;
        public UserRoleService(IUserRoleRepository repository)
        {
            _repository = repository;
        }
        public List<IdentityUserRole<int>> GetAll(CancellationToken cancellation)
        {
            return _repository.GetAll(cancellation);
        }

        //public IdentityUserRole<int> GetById(int Id, CancellationToken cancellation)
        //{
        //    return _repository.GetById(Id, cancellation);
        //}

        public List<IdentityUserRole<int>> GetByRoleId(int RoleId, CancellationToken cancellation)
        {
            var allUserRole = _repository.GetAll(cancellation);
            var markList = new List<IdentityUserRole<int>>();

            foreach(var userRole in allUserRole)
            {
                if(userRole.RoleId == RoleId)
                    markList.Add(userRole);
            }

            return markList;
        }

        public List<IdentityUserRole<int>> GetByUserId(int userId, CancellationToken cancellation)
        {
            var allUserRole = _repository.GetAll(cancellation);
            var markList = new List<IdentityUserRole<int>>();

            foreach (var userRole in allUserRole)
            {
                if (userRole.UserId == userId)
                    markList.Add(userRole);
            }

            return markList;
        }
    }
}
