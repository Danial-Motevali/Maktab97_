using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Service;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _repository;
        public RoleService(IRoleRepository repository)
        {
            _repository = repository;
        }
        public List<IdentityRole<int>> GetAll(CancellationToken cancellation)
        {
            return _repository.GetAll(cancellation);
        }

        public IdentityRole<int> GetById(int Id, CancellationToken cancellation)
        {
            return _repository.GetById(Id, cancellation);
        }
    }
}
