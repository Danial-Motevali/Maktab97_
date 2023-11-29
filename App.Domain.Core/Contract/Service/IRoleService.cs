using App.Domain.Core.Models.Identity.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IRoleService
    {
        IdentityRole<int> GetById(int Id, CancellationToken cancellation);

        List<IdentityRole<int>> GetAll(CancellationToken cancellation);
    }
}
