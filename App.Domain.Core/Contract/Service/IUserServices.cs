using App.Domain.Core.Entities;
using App.Domain.Core.Models.Identity.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Contract.Service
{
    public interface IUserServices
    {
        Task<bool> Add(User input, CancellationToken cancellation);

        Task<bool> Update(int Id, User input, CancellationToken cancellation);

        Task<bool> Delete(int Id, CancellationToken cancellation);

        Task<User> GetById(int Id, CancellationToken cancellation);

        List<User> GetAll(CancellationToken cancellation);
    }
}
