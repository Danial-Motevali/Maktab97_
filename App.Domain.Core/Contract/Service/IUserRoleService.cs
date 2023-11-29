using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IUserRoleService
    {
        //IdentityUserRole<int> GetById(int Id, CancellationToken cancellation);

        List<IdentityUserRole<int>> GetAll(CancellationToken cancellation);

        List<IdentityUserRole<int>> GetByUserId (int userId, CancellationToken cancellation);

        List<IdentityUserRole<int>> GetByRoleId (int RoleId, CancellationToken cancellation);
    }
}
